using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : MonoBehaviour 
{
	/**How much money does the player have?*/
	public int gold = 0;
	/**The character's level*/
	public int level = 1;
	/**The health of the chaeracter*/
	public float health = 100;
	/**The maximum health of the character*/
	public float maxHealth = 100;
	/**The character's attack power*/
	public float attack = 1;
	/**The character's defense*/
	public float defense = 1;
	/**The health amount at which this character will give up*/
	public float defeatThreshold = 0f;

	/**Is this character defending?*/
	private bool isDefending = false;

	/**The item which is held by this character*/
	public ItemSlot heldItem;

	/**This character's inventory*/
	public Inventory charInventory;

	public void Start()
	{
		if(charInventory == null)
			charInventory = GetComponent<Inventory>();
	}

	/**Hurt the character*/
	public void hurt(float amount, Entity source)
	{
		health -= amount;

		if(health < defeatThreshold)
			defeat(source);

		if(health <= 0)
			die();
	}

	/**Heal the character*/
	public void heal(float amount, Entity source)
	{
		health += amount;

		if(health > maxHealth)
			health = maxHealth;
	}

	/**Hurt the character*/
	public void hurt(float amount)
	{
		health -= amount;

		if(health <= 0)
			die();
	}

	/**Heal the character*/
	public void heal(float amount)
	{
		health += amount;

		if(health > maxHealth)
			health = maxHealth;
	}

	/**Called when this character is defeated (returns the amount of gold)*/
	public virtual int defeat(Entity source)
	{
		//Nothing
		return gold;
	}

	/**Called when the character dies*/
	public void die()
	{
		Destroy(this.gameObject);
	}

	/**Return the held item*/
	public ItemSlot getHeldItem()
	{
		return heldItem;
	}
		
	/**Get the defense of this character*/
	public float getDefense()
	{
		if(isDefending)
			return defense;
		else
			return 0;
	}

	/**Sets the defend status of this character*/
	public void setDefending(bool defend)
	{
		isDefending = defend;
	}
		
	/**Returns the characters' name*/
	public string getName()
	{
		return this.gameObject.name;
	}
}
