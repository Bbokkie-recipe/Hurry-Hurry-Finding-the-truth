using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogManager : MonoBehaviour
{

    public PhoneControl phoneControl;
    public StroyManager stroyManage;//오타..
    public MonoManager monoManage;
    public PhonePassword passwordSc;

    public GameObject itemInfoPanel;
    public GameObject YumiMonoPanel;
    public GameObject GangMonoPanel;
    public GameObject phonehintPanel;
    public GameObject globePanel;
    public GameObject NextSceneButton;
    public GameObject laptopPanel;
    public GameObject dialLockPanel;
    public GameObject chatPanel;

    private MonoData monotalk;
    public GameObject achievement;

    ObjData objInfo;
    public PhonePassword QuizPass;

    public Text missionText;
    //public TextMeshProUGUI talkText;
    public Text itemInfoText;
    public Text yumiMonoText;
    public Text GangMonoText;
    public GameObject scanObject;
    public GameObject scanObject2=null;

    public bool isSearch;
    public bool isSearchlaptop;
    public bool isMono;
    public int realizeSchool;
    public int yumitalkCount;
    public int infoIndex=0;
    private static int seeChatCount = 0;

    private void Start()
    {

        Debug.Log("allUnLock 시크릿값 잘 저장되었나 " + PlayerPrefs.GetInt("hasSecret", 1));
        Debug.Log("allUnLock 시크릿값 잘 저장되었나! " + PlayerPrefs.GetInt("hasSecret", 0));
        PlayerPrefs.SetInt("hasSecret", 0);
        if (chatPanel == null) chatPanel = null;
         ResetGame();
        YumiMono();//유미 첫 대사 호출
    }
    public void YumiMono()
    {
            YumiMonoPanel.SetActive(true);
            MonoData monotalk = YumiMonoPanel.GetComponent<MonoData>();
            MonoLine(monotalk.character_Id);
    }

    public void GangMono()
    {
        GangMonoPanel.SetActive(true);
        MonoData monotalk = GangMonoPanel.GetComponent<MonoData>();
        GangMonoLine(monotalk.character_Id);
    }

    //yumiStory(플레이어 스크립트)에서 if (Input.GetKeyDown(KeyCode.Space))시 호출
    public void Search(GameObject _scanObject)
    {
        //yumiStory 레이캐스트로 hit에 담은 GameObject scanObject 가져와서
        //컴포넌트 스크립트 ObjData 속 변수를 받아옴 (int id, bool isMainItem)
        scanObject = _scanObject;
        objInfo = scanObject.GetComponent<ObjData>();
        StoryLine(objInfo.id, objInfo.isMainItem);

        itemInfoPanel.SetActive(true);
        Pause();
        if (!isSearch)
        {
            itemInfoPanel.SetActive(false);
            ResetGame();
        }
        if(QuizPass.isachievement)
        {
            itemInfoPanel.SetActive(false);
            QuizPass.isachievement = false;
        }
    }

    public void Search2(GameObject _scanObject)
    {
        //yumiStory 레이캐스트로 hit에 담은 GameObject scanObject 가져와서
       if(isSearchlaptop)
        {
            isSearchlaptop = false;
            Invoke("LookChat", 0.01f);
            seeChatCount++;
            if (seeChatCount == 1) YumiMono();
        }
        else
        {
            scanObject2 = _scanObject;
            isSearchlaptop = true;
            Invoke("LookChat", 0.01f);
        }

    }
    void LookChat()
    {
        if(isSearchlaptop)
            chatPanel.SetActive(true);
        else
            chatPanel.SetActive(false);
    }

    public void Search3(GameObject _scanObject)
    {
        if(passwordSc.istruthSchool)
        {
            YumiMono();
        }
    }

    /*아이템Info대사 호출*/
    void StoryLine(int _idnum, bool isMainitem)
    {
        string infoData = stroyManage.GetData(_idnum, infoIndex);
        if (objInfo.id != 1000)
        {
            laptopPanel.SetActive(false);
        }
        else
        {
            laptopPanel.SetActive(true);
        }

        if (objInfo.id != 2000)
        {
            phonehintPanel.SetActive(false);
        }
        else
        {
            phonehintPanel.SetActive(true);
        }

        if (objInfo.id != 3000)
        {
            globePanel.SetActive(false);
        }
        else
        {
            globePanel.SetActive(true);
        }
        if (objInfo.id != 4000)
        {
            dialLockPanel.SetActive(false);
        }
        else
        {
            dialLockPanel.SetActive(true);
        }

        if (infoData == null)
        {
            isSearch = false;
            infoIndex = 0;
            return;
        }

        itemInfoText.text = infoData;
        isSearch = true;
        infoIndex++;
    }

    /*유미 독백대사 호출*/
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
            monotalk.character_Id++;
            Debug.Log("1"+yumitalkCount);
            Debug.Log("2"+monotalk.character_Id);
            if (yumitalkCount >= 3)
            {
                monotalk.character_Id--;
                realizeSchool++;
                if (realizeSchool == 1) Invoke("GangCall",0.5f);
            }
            Debug.Log("3" + yumitalkCount);
            Debug.Log("4" + monotalk.character_Id);
            if ((SceneManager.GetActiveScene().buildIndex ==1))
            {
                if (yumitalkCount == 2) NextSceneOpen();
            }
            return;
        }
        yumiMonoText.text = monoTalkData;
        isMono = true;
        infoIndex++;
    }

    void GangCall()
    {
        phoneControl.GetPhone();
    }

    /*광철 독백대사 호출*/
    void GangMonoLine(int _cahracter_idnum)
    {
        string monoTalkData2 = monoManage.GetMonoData(_cahracter_idnum, infoIndex);

        if (monoTalkData2 == null)
        {
            isMono = false;
            infoIndex = 0;
            GangMonoPanel.SetActive(false);
            monotalk = GangMonoPanel.GetComponent<MonoData>();
            monotalk.character_Id++;
            if (SceneManager.GetActiveScene().buildIndex == 1)YumiMono();
            //NextSceneOpen();
            if ((SceneManager.GetActiveScene().buildIndex == 3))
            {
                NextSceneOpen();
            }
            return;
        }
        GangMonoText.text = monoTalkData2;
        isMono = true;
        infoIndex++;
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
