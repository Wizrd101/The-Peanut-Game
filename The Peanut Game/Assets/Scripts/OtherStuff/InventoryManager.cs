using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public static InventoryManager Instance;

	public List<AllItems> _InventoryItems = new List<AllItems>(); //Our Inventory Items

	private void Awake()
	{
		Instance = this;
	}

	public void AddItem(AllItems item)		//Adds Items to Inventory
	{
		if (!_InventoryItems.Contains(item))
		{
			_InventoryItems.Add(item);
		}
	}

	public void RemoveItem(AllItems item)   //Removes Items from Inventory
	{
		if (_InventoryItems.Contains(item))
		{
			_InventoryItems.Remove(item);
		}
	}

	public enum AllItems // All available Inventory items in game
	{
		Card
	}
}
