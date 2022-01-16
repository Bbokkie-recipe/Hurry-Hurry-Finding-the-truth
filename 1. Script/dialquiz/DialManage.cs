using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialManage : MonoBehaviour
{
    public bool secreatlistGet = false;
    public GameObject itemInfoPanel;
    public GameObject oldBriefcase;
    public GameObject newBriefcase;
    public GameObject achievement;
    public GameObject secretList;

    public List<PerDial> perDial = new List<PerDial>();
    private const int maxDial = 4;
    public PerDial Dial_1;
    public PerDial Dial_2;
    public PerDial Dial_3;
    public PerDial Dial_4;
    private bool allUnLock;
    void Start()
    {
        //PlayerPrefs.GetInt("hasSecret", 0);
        if (PlayerPrefs.GetInt("hasSecret", 0) == 1)
        {
            allUnLock = false;
        }
        //allUnLock = false;
        perDial.Add(Dial_1);
        perDial.Add(Dial_2);
        perDial.Add(Dial_3);
        perDial.Add(Dial_4);
    }

    private void Update()
    {
        int temp = 0;
        for (int i = 0; i < perDial.Count; i++)
        {
            if (perDial[i].correct)
            {
                temp++;
            }
        }

        if (temp == 4)
        {
            allUnLock = true;
            if (allUnLock)
            {
                PlayerPrefs.SetInt("hasSecret", 1);
                CheckUnLock();
                Debug.Log("allUnLock 시크릿값 잘 저장되었나 " + PlayerPrefs.GetInt("hasSecret", 1));//다풀면 1
            }

        }
        else PlayerPrefs.SetInt("hasSecret", 0);
        Debug.Log("not allUnLock 시크릿값 잘 저장되었나 " + PlayerPrefs.GetInt("hasSecret", 1)); //안풀면 0
    }
    void CheckUnLock()
    {
        if(allUnLock)
        {
            itemInfoPanel.SetActive(false);
            newBriefcase.SetActive(true);
            oldBriefcase.SetActive(false);
            achievement.SetActive(true);
            itemInfoPanel.SetActive(false);
            secretList.SetActive(true);
            secreatlistGet = true;
        }
    }
    public void OnlyOneChoice()
    {
        if (perDial[0].active)
        {
            perDial[1].active = false;
            perDial[2].active = false;
            perDial[3].active = false;
        }
        else if(perDial[1].active)
        {
            perDial[0].active = false;
            perDial[1].active = false;
            perDial[2].active = false;
        }
        else if (perDial[2].active)
        {
            perDial[0].active = false;
            perDial[1].active = false;
            perDial[3].active = false;
        }
        else if (perDial[3].active)
        {
            perDial[0].active = false;
            perDial[1].active = false;
            perDial[2].active = false;
        }

    }
}