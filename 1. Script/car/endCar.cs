using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endCar : MonoBehaviour
{
    public bool isGo=false;
    private BoxCollider boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (isGo)
        {
            float _moveDirX = 0.05f * Time.deltaTime;
            float _moveDirZ = 0.5f * Time.deltaTime;
            transform.position = new Vector3(transform.position.x+ _moveDirX, transform.position.y, transform.position.z - _moveDirZ);

            if (transform.position.z <= -70f)
            {
                Destroy(gameObject);
            }
        }
    }



}
