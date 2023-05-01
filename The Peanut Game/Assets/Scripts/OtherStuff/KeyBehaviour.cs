using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
	[SerializeField] InventoryManager.AllItems _itemType;

	private void OnTriggerEnter(Collider other)
	{
		if (Collision.CompareTag("Player"))
		{

		}
	}
}
