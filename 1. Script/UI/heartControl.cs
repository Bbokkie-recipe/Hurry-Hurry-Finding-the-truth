using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class heartControl : MonoBehaviour
{
    const int heartnum = 3;
    Transform[] heartChild = new Transform[heartnum];
    Image[] heartImage = new Image[heartnum];

    public Sprite fullHeart; //바뀌어질 이미지
    public Sprite emptyHeart;

    public GameObject yumi;
    private yumiRun yumiScript;


void Start()
    {
        for (int i = 0; i < heartnum; i++)
        {
            heartChild[i] = transform.GetChild(i).gameObject.transform;
        }

        for (int i = 0; i < heartChild.Length; i++)
        {
            heartImage[i] = heartChild[i].GetComponent<Image>();
        }

        yumiScript = yumi.transform.GetComponent<yumiRun>();

        for (int i = 0; i < heartImage.Length; i++)
        {
            Debug.Log("들어왔냐" + heartImage[i].sprite);
            heartImage[i].sprite = fullHeart;
        }
    }

    private void Update()
    {
        ChangeheartImage();
    }

    public void ChangeheartImage()
    {

        for (int i = 0; i < heartnum; i++)
            heartImage[i].sprite = emptyHeart;
        for (int i=0;i<yumiScript.curHeart; i++)
            heartImage[i].sprite = fullHeart;

        /*
        if (yumiScript.maxHeart == 2)
        {
            heartImage[2].sprite = emptyHeart;
        }
        if (yumiScript.maxHeart == 1)
        {
            heartImage[1].sprite = emptyHeart;
        }
        if (yumiScript.maxHeart == 0)
        {
            heartImage[0].sprite = emptyHeart;
        }*/
    }

}
