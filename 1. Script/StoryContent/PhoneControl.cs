using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhoneControl : MonoBehaviour
{
    public dialogManager dialogmanager;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)Invoke("GetPhone", 1.3f);
    }

    public void GetPhone()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void MeetPhone()
    {
        dialogmanager.GangMono();
    }

}
