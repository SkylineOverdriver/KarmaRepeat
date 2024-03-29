﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour 
{
	/**The item in this itemslot*/
	public Item item;

	/**Return the item in the slot*/
	public virtual Item getItem()
	{
		if(item != null)
			return item;
		else
			return GameGlobals.globals.itemManager.getDefaultItem();
	}

	/**Sets the item in the slot*/
	public void setItem(Item newItem)
	{
		item = newItem;
	}
}