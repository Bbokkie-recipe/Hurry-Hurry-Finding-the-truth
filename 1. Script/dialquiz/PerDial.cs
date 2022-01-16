using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerDial : MonoBehaviour
{
    public Text Num_Txt;
    private int result;
    public int correctNum;

    public bool correct = false;
    public bool active = false;

    public void SetColor(float alphacolor)
    {
        Color color = Num_Txt.color;
        color.a = alphacolor;
        Num_Txt.color = color;
    }
    public void _Active()
    {
        active = true;
        SetColor(1f);
        StartCoroutine(RollNum());
    }
    public void _nonActive()
    {
        SetColor(0.5f);
        active = false;

    }
    void checkAnswer(int _result)
    {
        if (_result == correctNum) correct = true;
        else correct = false;
    }
    IEnumerator RollNum()
    {
        while (active)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SetNum("DOWN");
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetNum("UP");
            }
            yield return null;
        }
    }
    //public void Try_unLock()
    //{
    //    if (!access)
    //    {
    //        access = true;
    //        StartCoroutine(RollNum());
    //        SetColor();
    //    }
    //    else
    //    {
    //        access = false;
    //    }
    //}
    //public void SetColor()
    //{
    //    Color color = Num_Txt.color;
    //    color.a = 1f;
    //    Num_Txt.color = color;
    //}
    public void SetNum(string _arrow)
    {
        int result = int.Parse(Num_Txt.text);//선택된 박스 속 텍스트를 숫자형으로 강제 형변환 int.Parse
        if (_arrow == "DOWN")
        {
            if (result == 0)
                result = 9;
            else result--;
        }
        else if (_arrow == "UP")
        {
            if (result == 9)
                result = 0;
            else result++;
        }
        checkAnswer(result);
        Num_Txt.text = result.ToString();
    }
    //IEnumerator RollNum()
    //{
    //    while (access)
    //    {
    //        if (Input.GetKeyDown(KeyCode.DownArrow))
    //        {
    //            SetNum("DOWN");
    //        }
    //        else if (Input.GetKeyDown(KeyCode.UpArrow))
    //        {
    //            SetNum("UP");
    //        }
    //        yield return null;
    //    }
    //}
}
