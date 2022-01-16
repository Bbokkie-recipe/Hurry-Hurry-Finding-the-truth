using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endingDialogManage : MonoBehaviour
{
    public StroyManager storyManage;
    public MonoManager monoManage;
    public GameObject YumiMonoPanel;
    public GameObject GuardMonoPanel;
    public GameObject FatherMonoPanel;
    public GameObject NextSceneButton;
    public GameObject Item_bubble;
    public GameObject SecretItem;
    public GameObject Guard;
    public GameObject Yumi;
    public GameObject Car;
    public endCar _endCar;

    private MonoData monotalk;
    public MonoData monotalk1;//유미
    public MonoData monotalk2;//국정원
    public MonoData monotalk3;//아버지

    public Text yumiMonoText;
    public Text GuardMonoText;
    public Text FatherMonoText;

    public bool isMono;
    public bool isSearchGuard;
    public bool isDrive = false;
    public bool talkEnd = false;

    public int yumitalkCount;
    public int GuardtalkCount;
    public int FathertalkCount;
    public int infoIndex = 0;

    public GameObject scanObject2 = null;
    public GameObject scanObject1 = null;
    private static int seeGuardCount = 0;

    void Start()
    {
        /*엔딩분기점: 비밀문서 보유여부*/
        if (PlayerPrefs.GetInt("hasSecret", 1) == 1)
        {
            SecretItem.SetActive(true);
            monotalk1.isSecretItem = true;
            monotalk2.isSecretItem = true;
            monotalk3.isSecretItem = true;
        }
        else
        {
            SecretItem.SetActive(false);
            monotalk1.isSecretItem = false;
            monotalk2.isSecretItem = false;
            monotalk3.isSecretItem = false;
        }

        ResetGame();
        YumiMono();//유미 첫 대사 호출

    }

    public void YumiMono()
    {
        YumiMonoPanel.SetActive(true);
        MonoData monotalk = YumiMonoPanel.GetComponent<MonoData>();
        MonoLine(monotalk.character_Id);
    }
    public void GuardMono()
    {
        GuardMonoPanel.SetActive(true);
        MonoData monotalk = GuardMonoPanel.GetComponent<MonoData>();
        GuardMonoLine(monotalk.character_Id);
    }
    public void FatherMono()
    {
        if (isDrive)
        {
            FatherMonoPanel.SetActive(true);
            MonoData monotalk = FatherMonoPanel.GetComponent<MonoData>();
            FatherMonoLine(monotalk.character_Id);
        }
    }
    public void Search1(GameObject _scanObject)
    {
        //yumiStory 레이캐스트로 hit에 담은 GameObject scanObject 가져와서
        if (PlayerPrefs.GetInt("hasSecret", 1) == 1)
        {
            isDrive = true;
            scanObject1 = _scanObject;
            Invoke("FatherMono", 0.01f);
        }
        else
        {
            isDrive = false;
            Invoke("YumiBye", 1.5f);
        }
    }
    /*처음 가드를 만났을 때*/
    public void Search2(GameObject _scanObject)
    {
        //yumiStory 레이캐스트로 hit에 담은 GameObject scanObject 가져와서
        if (isSearchGuard)
        {
            isSearchGuard = false;
            Invoke("LookGuard", 0.01f);
            seeGuardCount++;
            if (seeGuardCount == 1) YumiMono();
        }
        else
        {
            scanObject2 = _scanObject;
            isSearchGuard = true;
            Invoke("LookGuard", 0.01f);
        }
    }
    public void Search3(GameObject _scanObject)
    {
        //yumiStory 레이캐스트로 hit에 담은 GameObject scanObject 가져와서
        //if (isSearchGuard)
        //{
        //    isSearchGuard = false;
        //    Invoke("LookGuard", 0.01f);
        //    seeGuardCount++;
        //    if (seeGuardCount == 1) YumiMono();
        //}
        //else
        //{
        //    scanObject2 = _scanObject;
        //    isSearchGuard = true;
        //    Invoke("LookGuard", 0.01f);
        //}
    }

    void LookGuard()
    {
        if (isSearchGuard)
            GuardMono();
    }

    public void ClickSecret()
    {
        if (GuardtalkCount == 1) Invoke("GuardMono", 1.0f);
    }
    public void NoSecret()
    {
        Invoke("GuardMono", 1.0f);
    }
    /*유미 대사 호출*/
    void MonoLine(int _cahracter_idnum)
    {
        string monoTalkData = monoManage.GetMonoData(_cahracter_idnum, infoIndex);
        if (monoTalkData == null)
        {
            isMono = false;
            infoIndex = 0;
            YumiMonoPanel.SetActive(false);
            monotalk = YumiMonoPanel.GetComponent<MonoData>();
            yumitalkCount++;
            if (monotalk1.isSecretItem) monotalk.character_Id++;
            monotalk.character_Id++;
            if (GuardtalkCount == 2) Invoke("GuardMono", 1.5f);
            return;
        }
        yumiMonoText.text = monoTalkData;
        isMono = true;
        infoIndex++;
    }
    /*국정원 대사 호출*/
    void GuardMonoLine(int _cahracter_idnum)
    {
        string monoTalkData2 = monoManage.GetMonoData(_cahracter_idnum, infoIndex);

        if (monoTalkData2 == null)
        {
            isMono = false;
            infoIndex = 0;
            GuardMonoPanel.SetActive(false);
            monotalk = GuardMonoPanel.GetComponent<MonoData>();
            GuardtalkCount++;
            if (monotalk2.isSecretItem) monotalk.character_Id += 2;
            monotalk.character_Id++;
            if (GuardtalkCount == 1 && !monotalk2.isSecretItem)
            {
                Invoke("NoSecret", 1.0f);
            }
            if (GuardtalkCount == 2) Invoke("YumiMono", 1.5f);
            if (GuardtalkCount == 3)
            {
                if (monotalk2.isSecretItem) monotalk.character_Id -= 2;
                monotalk.character_Id--;
                talkEnd = true;
                Guard.SetActive(false);
            }
            return;
        }
        GuardMonoText.text = monoTalkData2;
        isMono = true;
        infoIndex++;
    }

    /*아빠 대사 호출*/
    void FatherMonoLine(int _cahracter_idnum)
    {
        string monoTalkData3 = monoManage.GetMonoData(_cahracter_idnum, infoIndex);
        if (monoTalkData3 == null)
        {
            isMono = false;
            infoIndex = 0;
            FatherMonoPanel.SetActive(false);
            Invoke("YumiBye", 1.5f);
            Yumi.SetActive(false);

            monotalk = GuardMonoPanel.GetComponent<MonoData>();
            FathertalkCount++;
            if (GuardtalkCount == 1)
            {
                FathertalkCount--;
            }
        }
        FatherMonoText.text = monoTalkData3;
        isMono = true;
        infoIndex++;
    }
    public void YumiBye()
    {
        Yumi.SetActive(false);
        Invoke("CarBye", 1.5f);
    }
    public void CarBye()
    {
        _endCar.isGo = true;
        NextSceneButton.SetActive(true);
    }
    public void ResetGame()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    void NextSceneOpen()
    {
        NextSceneButton.SetActive(true);
    }

}
