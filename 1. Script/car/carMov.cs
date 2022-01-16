using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMov : MonoBehaviour
{
    private BoxCollider boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    void Update()
    {
            float _moveDirX = 3f * Time.deltaTime;
            transform.position = new Vector3(transform.position.x - _moveDirX, transform.position.y, transform.position.z);

            if (transform.position.x <= -10f)
            {
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boxCollider.enabled = false;
        }
    }
}
