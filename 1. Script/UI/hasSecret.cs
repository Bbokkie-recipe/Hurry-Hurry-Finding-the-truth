using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hasSecret : MonoBehaviour
{
    public Sprite lockImg; //바뀌어질 이미지
    public Sprite secretImg;
    Image nowImage;

    private void Awake()
    {
        Debug.Log("시크릿값 잘 저장되었나 "+ PlayerPrefs.GetInt("hasSecret", 1));
        nowImage = GetComponent<Image>();
        //secretImg.Rect = new Rect(0, 0, secretImg.width, secretImg.height);

    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("hasSecret", 1)==0)
            nowImage.sprite = lockImg;
        else
        {
            nowImage.sprite = secretImg;
            RectTransform rect = (RectTransform)nowImage.transform;
            rect.sizeDelta = new Vector2(100, 100);
            nowImage.sprite = secretImg;
        }
        //if (PlayerPrefs.GetInt("hasSecret", 1) == 1)
        //{
        //    nowImage.sprite = secretImg;
        //    RectTransform rect = (RectTransform)nowImage.transform;
        //    rect.sizeDelta = new Vector2(100,100);
        //    nowImage.sprite = secretImg;
        //}
        //else nowImage.sprite = lockImg;
    }

}
