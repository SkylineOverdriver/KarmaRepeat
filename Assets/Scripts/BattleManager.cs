using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour 
{
	/**The player who is fighting the enemy*/
	public Player player;
	/**The enemy that the player is fighting*/
	public CharacterEntity enemy;

	//Button variables
	public Button attackButton;
	public Button defendButton;
	public Button healButton;
	public Button runButton;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/**Advnces the battle by a step*/
	public void advanceBattle()
	{
		
	}

	/**Performs a player action*/
	public void playerAction(int action)
	{
		
	}

	/**Randomly performs an action (On the enemies behalf)*/
	public string enemyAction(int action)
	{
		if(action == -1)
		{
			action = Random.Range(0, 3);
		}

		switch(action)
		{
		case 0:
			return "";
		case 1:
			return "";
		case 2:
			return "";
		default:
			return "null action";
		}
	}

	/**Performs an action on the sender to the target
	 * -1 is random
	 * 0 is attack target
	 * 1 is defend from target
	 * 2 is attempt to heal
	 * 3 is attempt to run
	 */
	public string performAction(int action, CharacterEntity sender, CharacterEntity target)
	{
		string resultMessage = "nothing happened";

		if(action == -1)
		{
			action = Random.Range(0, 4);
		}

		sender.setDefending(false);

		switch(action)
		{
		case 0:
			//Attack the target, calculate defense
			Item senderWeapon = sender.getHeldItem().getItem();
			float totalDamage = senderWeapon.getDamage() - target.getDefense();

			if(totalDamage < 1)
			{
				totalDamage = 0;
				resultMessage = target.getName() + " defended " + target.getName() + "'s attack";
			}
			else
			{
				target.hurt(totalDamage);
				resultMessage = sender.getName() + " attacked " + target.getName() + " with " + senderWeapon.getName() + " for " + totalDamage + " damage";
			}
			

		case 1:
			//Make sender defend
			sender.setDefending(true);
			resultMessage = sender.getName() + " is defending";
		case 2:
			
			resultMessage = "";
		case 3:
			
			resultMessage = "";
		default:
			
			resultMessage = "...";
		}

		updateButtons();

		return resultMessage;
	}

	/**Changes the buttons so they comply with the player's stats*/
	public void updateButtons()
	{
		if(player.charInventory.hasItem())
		{
			
		}
	}
}
