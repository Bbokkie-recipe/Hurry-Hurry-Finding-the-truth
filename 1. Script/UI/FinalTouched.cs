using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTouched : MonoBehaviour
{
    public AudioSource BGM;
    public bool isfinalTouch = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BGM.Stop();
            transform.GetChild(0).gameObject.SetActive(true);//particle
            transform.GetChild(1).gameObject.SetActive(true);//sound
            isfinalTouch = true;
        }
    }


}
