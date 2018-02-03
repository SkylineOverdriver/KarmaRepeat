using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	/**The item toolbar*/
	public ItemSlot[] itemSlots = new ItemSlot[7];
	/**The index of the selected slot*/
	public int selectedSlotID = 0;

	/**Set the item in a slot to another*/
	public void changeItem(Item newItem, int slotID)
	{
		if(slotID < itemSlots.Length)
			itemSlots[slotID].setItem(newItem);
		else
			Debug.Log("Tried to set item " + newItem.gameObject.name + " to slot " + slotID);
	}

	/**Adds an item to the list of existing items*/
	public bool addItem(Item newItem)
	{
		for(int i = 0; i < itemSlots.Length; i++)
		{
			if(itemSlots[i] == null)
			{
				itemSlots[i].setItem(newItem);
				return true;
			}
		}
		return false;
	}
}
