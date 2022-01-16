using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource buttonSound;
    int sceneNum = 0;
    public string levelName;

    void OnEnable()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }
    public void MusicStop()
    {
        BGM.Stop();
    }
    public void ButtonSound()
    {
        buttonSound.Play();
    }
    public void NextSceneGo()
    {
        Invoke("NextScene", 0.2f);
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenuGo()
    {
        //SceneManager.LoadScene(levelName);
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitButtonPressed()
    {
        Application.Quit();
    }


}
