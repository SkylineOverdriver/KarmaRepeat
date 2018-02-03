using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	/**All the items which the player can aquire*/
	public Item[] items;
	/**Has the item manager been loaded*/
	public static bool loaded = false;

	// Use this for initialization
	void Start () 
	{
		if(!loaded)
		{
			DontDestroyOnLoad(this.gameObject);
			loaded = true;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
		
	/**Returns an item by its ID*/
	public Item getItem(int id)
	{
		if(id < items.Length)
			return items[id];
		else //Return the default item
			return items[0];
	}

	/**Returns the default item*/
	public Item getDefaultItem()
	{
		return items[0];
	}
}
