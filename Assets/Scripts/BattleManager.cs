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

	/**Text for battle log*/
	public Text battleLogText;
	/**The UI screen which blacks out the rest of the screen*/
	public GameObject blackoutUIScreen;

	/**Who's turn is it?*/
	public bool playerTurn = true;
	/**Is a battle happening right now*/
	public bool inBattle = false;

	// Use this for initialization
	void Start () 
	{
		GameGlobals.globals.level.battleManager = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(inBattle)
		{
			if(playerTurn)
			{
				//Do nothing
			}
			else
			{
				enemyAction(-1);
			}
		}
	}

	/**Adavnces the battle by a step*/
	public void advanceBattle()
	{
		
	}

	/**Performs a player action*/
	public void playerAction(int action)
	{
		performAction(action, player, enemy);
		playerTurn = false;
	}

	/**Randomly performs an action (On the enemies behalf)*/
	public void enemyAction(int action)
	{
		performAction(action, enemy, player);
		playerTurn = true;
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
		string resultMessage = "Nothing happened";

		//Randomly get the action if -1
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
			
			break;
		case 1:
			//Make sender defend
			sender.setDefending(true);
			resultMessage = sender.getName() + " is defending";
			break;
		case 2: //No check, button will be disabled if not avalible
			sender.heal(sender.getInventory().findItemType(ItemType.HEALING).getHealing());
			resultMessage = "";
			break;
		case 3: //No check, button will be disabled if not avalible
			endBattle();
			resultMessage = "";
			break;
		default:
			//Fallback message
			resultMessage = "...";
			break;
		}

		updateButtons();

		logBattleMessage(resultMessage);

		return resultMessage;
	}


	/**Called when the battle starts*/
	public void beginBattle(CharacterEntity enemyTarget)
	{
		enemy = enemyTarget;
		inBattle = true;
		blackoutUIScreen.SetActive(true);
	}

	/**Called when the battle ends*/
	public void endBattle()
	{
		if(!player.getDead())
		{
			//Give out xp and rewards
			player.addExp(enemy.calculateExpValue());
			player.addGold(enemy.calculateGoldValue());
			logBattleMessage(enemy.getDefeatMessage());
		}
		else
		{
			logBattleMessage(player.getDefeatMessage());
		}
		inBattle = false;
	}

	/**Changes the buttons so they comply with the player's stats*/
	public void updateButtons()
	{
		healButton.interactable = player.charInventory.hasItemType(ItemType.HEALING);
		runButton.interactable = !(Mathf.Abs(player.level - enemy.level) > 5);
		//Other two buttons are always enabled
	}

	/**When should the messages start claring*/
	private int battleMessageMax = 6;
	/**The battle messages to display*/
	private List<string> battleMessages = new List<string>();

	/**Adds a message to the battle output box*/
	public void logBattleMessage(string message)
	{
		
		battleMessages.Add(message);

		if(battleMessages.Count > battleMessageMax)
			battleMessages.RemoveAt(0);

		battleLogText.text = "";
		foreach(string s in battleMessages)
			battleLogText.text += s + "\n";
	}
}
