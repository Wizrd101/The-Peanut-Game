using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public partial class InventoryManager : MonoBehaviour
{
	public static InventoryManager Instance;

	public List<AllItems> _inventoryItems = new List<AllItems>(); //Our Inventory Items

	private void Awake()
	{
		Instance = this;
	}

	public void AddItem(AllItems item)		//Adds Items to Inventory
	{
		if (!_inventoryItems.Contains(item))
		{
			_inventoryItems.Add(item);
		}
	}

	public void RemoveItem(AllItems item)   //Removes Items from Inventory
	{
		if (_inventoryItems.Contains(item))
		{
			_inventoryItems.Remove(item);
		}
	}

	public enum AllItems // All available Inventory items in game
	{
		KeyCard1,
		KeyCard2,
		KeyCard3,
	}
}
