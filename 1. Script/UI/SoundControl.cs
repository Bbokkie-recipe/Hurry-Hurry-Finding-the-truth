using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public Image soundImg; //기존 이미지
    public Sprite off; //바뀌어질 이미지
    public Sprite on;

    void Awake()
    {
        soundImg = GetComponent<Image>();

        if (PlayerPrefs.GetInt("Mute", 0) == 1)//음악이 꺼져있다면
        {
            AudioListener.volume = 0;//소리 0으로 초기화
            soundImg.sprite = off;
        }
        else//음악이 켜져있다면
        {
            AudioListener.volume = 1;//소리 1로 초기화
            soundImg.sprite = on;
        }
    }

    void ChangeImage()
    {
        /*
        https://netpilgrim.net/778?category=659393
        */
        Debug.Log("별 희안한 버그가 다 있네");
            if (PlayerPrefs.GetInt("Mute", 0) == 0)//음악이 켜져있다면
            {
            Debug.Log("별 111네");
            AudioListener.volume = 0;//소리줄이고
                PlayerPrefs.SetInt("Mute", 1);//뮤트상태로 전환
                soundImg.sprite = off;
            }
            else//음악이 꺼져있다면
            {
            Debug.Log("별222네");
            AudioListener.volume = 1;//소리키우고
                PlayerPrefs.SetInt("Mute", 0);//뮤트풀기
                soundImg.sprite = on;
            }
        PlayerPrefs.Save();

    }

}
