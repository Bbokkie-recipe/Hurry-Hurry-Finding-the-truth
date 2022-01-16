using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawn : MonoBehaviour
{
    private Transform carSpawnpoint;
    public GameObject[] carPrefabs;
    public bool left;

    void Start()
    {
        StartCoroutine(spawn_Car());
    }


    IEnumerator spawn_Car()
    {
        while (true)
        {
            int randCar = Random.Range(0, carPrefabs.Length);
            float randTime = Random.Range(1.4f, 1.7f);
            GameObject startCar = Instantiate(carPrefabs[randCar], transform.position, Quaternion.identity);
            startCar.transform.localScale = new Vector3(this.transform.localScale.x * 3, this.transform.localScale.y * 3, this.transform.localScale.z * 3);
            if (left)
            {
                startCar.transform.Rotate(0f, -90f, 0f);
                yield return new WaitForSecondsRealtime(randTime);
            }
            else
            {
                startCar.transform.Rotate(0f, 90f, 0f);
                yield return new WaitForSecondsRealtime(randTime);
            }

        }
    }
}
