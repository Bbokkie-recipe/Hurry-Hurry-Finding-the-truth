using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject settings;
    public AudioSource buttonAudio;
    AudioSource BGM;
    private float musicVolume;
    public Slider musicValue;

    private void Start()
    {
        BGM=GetComponent<AudioSource>();
    }
    void Update()
    {
        musicVolume = musicValue.value;
        BGM.volume = musicVolume;
    }
    public void GameShow()
    {
        buttonAudio.Play();
        SceneManager.LoadScene(1);
    }

    public void BGMStop()
    {
        BGM.Stop();
        SceneManager.LoadScene(1);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void SettingShow()
    {
        settings.SetActive(true);
    }
    public void SettingNoShow()
    {
        settings.SetActive(false);
    }
    public void updateVolume(float _volume)
    {
        musicVolume = _volume;
    }

}
