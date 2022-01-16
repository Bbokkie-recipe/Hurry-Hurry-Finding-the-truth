using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemspawnTrigger : MonoBehaviour
{
    const int itemNum = 4;
    Transform[] itemChild = new Transform[itemNum];

    void Start()
    {
        for (int i = 0; i < itemNum; i++)
        {
            itemChild[i] = transform.GetChild(i).gameObject.transform;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < itemNum; i++)
            {
                itemChild[i].gameObject.SetActive(true);
            }
        }

    }

}
