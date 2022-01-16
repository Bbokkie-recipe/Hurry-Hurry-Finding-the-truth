using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemboxes : MonoBehaviour
{
	public enum Type
    {
		AccelItem,
		RandItem,
		heartItem,
		ShieldItem,
		FireworkItem
	}
	public Type itemType;
	public int value;



    private void OnTriggerEnter(Collider other)
	{
		//if (other.gameObject.tag == "Player")
		//{
		//	gameObject.SetActive(false); 
		//}

	}
	void Update()
	{
		transform.Rotate(new Vector3(0, -0.45f, 0));
	}
}
