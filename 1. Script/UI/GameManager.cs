using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header("GameObj")]
    public GameObject player;
    private yumiRun yumiScript;
    public RunAi[] runPolice;
    public GameObject yumiSound;
   
    [Header("UIObj")]
    public GameObject OptionSetUI;
    public GameObject gameOverUI;
    public GameObject gamePassUI;
    public GameObject pauseUI;
    PauseControl pauseUIScript;
    public GameObject DontExitUI;
    public FinalTouched FinalTouchSc;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        //SpeedRand();
    }
    void Start()
    {
        pauseUIScript = pauseUI.GetComponent<PauseControl>();
        yumiScript = player.GetComponent<yumiRun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FinalTouchSc.isfinalTouch)
        {
            Invoke("gamePass", 0.5f);
        }
        if (!DontExitUI.activeSelf)
        {
            if (yumiScript.isDead)
            {
                Invoke("gameOver", 0.5f);
                //Pause();
            }
        }

        if (OptionSetUI.activeSelf || !pauseUIScript.isPlay)
        {
            yumiSound.SetActive(false);
            Pause();
        }
        else ResetGame();

            if (Input.GetButtonDown("Cancel"))
        {
            if (OptionSetUI.activeSelf) OptionSetUI.SetActive(false);
            else OptionSetUI.SetActive(true);
        }
    }

    //void SpeedRand()
    //{
    //    for (int i = 0; i < runPolice.Length; i++)
    //    {
    //        runPolice[i].manSpeed = Random.Range(runPolice[i].manSpeed+0.1f, runPolice[i].manSpeed - 0.1f);
    //    }
    //}

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void gamePass()
    {
        gamePassUI.SetActive(true);
        //Pause();
    }

    public void settingMenuShow()
    {
        OptionSetUI.SetActive(true);
    }
    public void ResetGame()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void RestartButtonPressed()
    {
        ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
