using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    public Image pauseImage; //기존 이미지
    public Sprite playImg; //바뀌어질 이미지
    public Sprite pauseImg;
    AudioSource buttonAudio;
    public GameObject yumiSound;
    public bool isPlay;
    void Awake()
    {
        pauseImage = GetComponent<Image>();
        //if (PlayerPrefs.GetInt("Play", 0) == 1)
        //{
        //    Time.timeScale = 0f;
        //    pauseImage.sprite = playImg;
        //}
        //else
        //{
        Time.timeScale = 1f;
        pauseImage.sprite = pauseImg;
        isPlay = true;
        //}
    }

    private void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
    }

    public  void ChangepauseImage()
    {
        yumiSound.SetActive(false);
        buttonAudio.Play();

        if (pauseImage.sprite == pauseImg)
        {
            isPlay = false;
            pauseImage.sprite = playImg;
        }
        else
        {
            isPlay = true;
            pauseImage.sprite = pauseImg;
        }
        //if (PlayerPrefs.GetInt("Play", 0) == 0)
        //{
        //    Time.timeScale = 0f;
        //    PlayerPrefs.SetInt("Play", 1);
        //    pauseImage.sprite = playImg;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //    PlayerPrefs.SetInt("Play", 0);
        //    pauseImage.sprite = pauseImg;
        //}
        //PlayerPrefs.Save();

    }
}
