using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenWithKey : MonoBehaviour
{

	public Animator animator;
	public DoorAnimation DoorAnimation;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player") && GameVariables.keyCount > 0)
		{
			GameVariables.keyCount--;
			DoorAnimation.Open();
		}
	}
}
