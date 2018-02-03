using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{
	/**How much is this item worth*/
	public long itemValue = 0;
	/**The item's sprite*/
	public Sprite itemSprite;

	/**How much damage does this item do*/
	public float damage = 0;
	/**How much healing does this item do*/
	public float healing = 0;
	/**How much defense does this item add to the player*/
	public  float defense = 0;

	/**The type of item that this is*/
	public ItemType itemType = ItemType.GENERIC;

	/**Returns true if this item was successful in being used*/
	public virtual bool itemUse()
	{
		return false;
	}

	/**The sprite which this item uses*/
	public Sprite getSprite()
	{
		return itemSprite;
	}

	/**Returns the damage dealt by this item*/
	public float getDamage()
	{
		return damage;
	}

	/**Returns the hp healed by this item*/
	public float getHealing()
	{
		return healing;
	}

	/**Return the name of this item*/
	public string getName()
	{
		return this.gameObject.name;
	}

	/**Return the type of item*/
	public ItemType getItemType()
	{
		return itemType;
	}

	/**Returns the cost of the item (in gold)*/
	public long getGoldValue()
	{
		return itemValue;
	}
}

public enum ItemType : int
{
	GENERIC = -1,
	WEAPON_GENERIC = 0,
	HEALING = 1,
	QUEST = 2,
	WEAPON_MELE = 3,
	WEAPON_MAGIC = 4,
	WEAPON_RANGED = 5,
	POTION = 6,
};
