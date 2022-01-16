using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetMov : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        target = GetComponent<Transform>();

    }

    void Update()
    {
        float _moveDirZ =10f * Time.deltaTime;
        transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z+ _moveDirZ);
    }
}
