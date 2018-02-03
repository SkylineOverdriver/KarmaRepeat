using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEntity : MonoBehaviour 
{
	/**How much money does the character have?*/
	public long gold = 0;
	/**The character's level*/
	public int level = 1;
	/**Hoe much exp does the chaeracter have*/
	public long exp = 0;
	/**How much exp to the next level*/
	public long maxExp = 1;
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
	/**Is this character dead*/
	private bool isDead = false;

	/**The item which is held by this character*/
	public ItemSlot heldItem;

	/**This character's inventory*/
	public Inventory charInventory;

	/**The image for the healthbar*/
	public Image healthBarImage;

	public virtual void Start()
	{
		if(charInventory == null)
			charInventory = GetComponent<Inventory>();
	}

	/**Hurt the character*/
	public void hurt(float amount)
	{
		health -= amount;

		if(health <= 0)
			die();

		updateHealthUI();
	}

	/**Heal the character*/
	public void heal(float amount)
	{
		health += amount;

		if(health > maxHealth)
			health = maxHealth;

		updateHealthUI();
	}

	/**Called when this character is defeated (returns the amount of gold)*/
	public virtual long defeat(Entity source)
	{
		//Nothing
		return gold;
	}

	/**Called when the character dies*/
	public void die()
	{
		isDead = true;
		//TODO: IMPLEMENT A DEATH SEQUENCE
		//Destroy(this.gameObject);
	}

	/**Return the held item*/
	public ItemSlot getHeldItem()
	{
		return getInventory().getSelectedItem();
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

	/**Returns the characters inventory*/
	public Inventory getInventory()
	{
		return charInventory;
	}

	/**Updates the health UI of the character*/
	public virtual void updateHealthUI() 
	{
		if(healthBarImage != null)
			healthBarImage.fillAmount = health / maxHealth;
	}

	/**Add exp to the player's total*/
	public void addExp(long amount)
	{
		exp += amount;

		if(exp > maxExp)
		{
			level++;
			exp -= maxExp;
			maxExp *= 2; //TODO: Make the EXP rate change better (its just 2x right now)
		}
	}

	/**Returns the character's value in exp*/
	public int calculateExpValue()
	{
		return (level * 10) + (int) getDefense() + (int) (attack / 2);
	}

	/**Adds gold to the total*/
	public void addGold(long amount)
	{
		gold += amount;
	}

	/**Checks to see if the character has the gold they need*/
	public bool hasGold(long amount)
	{
		if(gold >= amount)
			return true;
		else
			return false;
	}

	/**Removes gold from the character*/
	public bool removeGold(int amount)
	{
		if(hasGold(amount))
		{
			gold -= amount;
			return true;
		}
		else
		{
			return false;
		}
	}

	/**Returns the value of the enemy in gold*/
	public long calculateGoldValue()
	{
		return gold + getInventory().getGoldValue();
	}

	/**Returns the defeat message of this character*/
	public string getDefeatMessage()
	{
		return getName() + " was defeated";
	}

	/**Is this character dead*/
	public bool getDead()
	{
		return isDead;
	}
}
