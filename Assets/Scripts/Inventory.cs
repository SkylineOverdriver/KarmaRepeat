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

	/**Returns true if the inventory has the type of item*/
	public bool hasItemType(ItemType type)
	{
		foreach(ItemSlot slot in itemSlots)
		{
			if(slot.getItem().getItemType() == type)
			{
				return true;
			}
		}
		return false;
	}

	/**Returns the first index of the type of the item*/
	public Item findItemType(ItemType type)
	{
		foreach(ItemSlot slot in itemSlots)
		{
			if(slot.getItem().getItemType() == type)
			{
				return slot.getItem();
			}
		}
		return GameGlobals.globals.itemManager.getDefaultItem();
	}

	/**Returns the value of this inventory in gold*/
	public long getGoldValue()
	{
		long goldVal = 0;

		foreach(ItemSlot slot in itemSlots)
		{
			goldVal += slot.getItem().getGoldValue();
		}

		return goldVal;
	}

	/**Gets the selected item*/
	public ItemSlot getSelectedItem()
	{
		if(selectedSlotID >= 0 && selectedSlotID < itemSlots.Length)
			return itemSlots[selectedSlotID];
		else
			return null;
	}
}
