using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    public static bool isGo;

    public GameObject carSpawn;

    void Start()
    {
        isGo = false;
        StartCoroutine(_CountDown());
    }
    IEnumerator _CountDown()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = string.Format("{0}", i);
            yield return new WaitForSeconds(1f);
        }
        countDownText.text = string.Format("GO!");
        isGo = true;
        carSpawn.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
        yield return null;
    }
    //IEnumerator LoadScene()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    _slider.value = 0;
    //    int i = 0;
    //    for (i = 10; i > 0; i--)
    //    {
    //        _slider.value += 0.1f;
    //        yield return new WaitForSeconds(1f);
    //    }
    //    if (i <= 1) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    yield return null;
    //}


}
