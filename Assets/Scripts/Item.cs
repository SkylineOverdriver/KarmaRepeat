using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour 
{
	/**How much is this item worth*/
	public int itemValue = 0;
	/**The item's sprite*/
	public Sprite itemSprite;

	/**How much damage does this item do*/
	public float damage = 0;
	/**How much healing does this item do*/
	public float healing = 0;
	/**How much defense does this item add to the player*/
	public  float defense = 0;

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
}
