using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PhonePassword : MonoBehaviour
{

    public bool isPhoneOpen = false;
    public bool isLaptopOpen = false;
    public bool isChatOpen = false;
    public bool istruthSchool = false;

    public GameObject oldLaptop;
    public GameObject newLaptop;
    public GameObject smartPhone;
    public GameObject achievement;
    public GameObject realPhone;
    public GameObject itemInfoPanel;
    public GameObject yumiTalk;
    public GameObject guardTalk;

    const string answer = "Seoul";
    const string answer1 = "SEOUL";
    const string answer2 = "seoul";

    const string loveAnswer = "Yumi";
    const string loveAnswer1 = "YUMI";
    const string loveAnswer2 = "yumi";

    const string truthAnswer = "truth";
    const string truthAnswer1 = "Truth";
    const string truthAnswer2 = "TRUTH";

    public Text inputText;
    public Text inputText2;
    public bool isachievement=false;
    public string txt;

    public bool achieve()
    {
        isachievement = true;
        return isachievement;
    }
    public void FuncButton()
    {
        txt = inputText.text;
        CheckAnswer(txt);
    }
    public void FuncButton2()
    {
        txt = inputText.text;
        CheckAnswer2(txt);
    }
    public void FuncButton3()
    {
        txt = inputText2.text;
        CheckAnswer3(txt);
    }

    private void CheckAnswer(string _txt)
    {
        if ((_txt == answer) || (_txt == answer1) || (_txt == answer2))
        {
            isPhoneOpen = true;
            Answer();
        }
    }
    private void CheckAnswer2(string _txt)
    {
        if ((_txt == loveAnswer) || (_txt == loveAnswer1) || (_txt == loveAnswer2))
        {
            isLaptopOpen = true;
            achieve();
            //Destroy(oldLaptop.gameObject);
            oldLaptop.SetActive(false);
            itemInfoPanel.SetActive(false);
            newLaptop.SetActive(true);
            Answer2();
        }
    }

    private void CheckAnswer3(string _txt)
    {
        if ((_txt == truthAnswer) || (_txt == truthAnswer1) || (_txt == truthAnswer2))
        {
            isChatOpen = true;
            achieve();
            //Destroy(oldLaptop.gameObject);
            yumiTalk.SetActive(true);
            Invoke("GoSchool",3f);
            //Answer3();
        }
    }
    void GoSchool()
    {
        guardTalk.SetActive(true);
        istruthSchool = true;
    }
    public void Answer()
    {
        if (isPhoneOpen)
        {
            realPhone.SetActive(true);
            achievement.SetActive(true);
            itemInfoPanel.SetActive(false);
            smartPhone.SetActive(false);
        }
    }
    public void Answer2()
    {
        if (isLaptopOpen)
        {
            oldLaptop.SetActive(false);
            achievement.SetActive(true);
            itemInfoPanel.SetActive(false);
        }
    }
    //public void Answer3()
    //{
    //    if (isLaptopOpen)
    //    {
    //        oldLaptop.SetActive(false);
    //        achievement.SetActive(true);
    //        itemInfoPanel.SetActive(false);
    //    }
    //}

}


