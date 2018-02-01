using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour {

	/**The name of this trade*/
	public string tradeName = "";

	/**A list of all existing trades*/
	public static readonly string[] TRADES = new string[]{"Fighter", "Alchemist", "Florist", "Blacksmith", "Wizard"};

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/**All the abilities whih you can get from this trade*/
	public List<TradeAbility> abilities;
}

[System.Serializable]
public class TradeAbility
{
	/**Is this ability active*/
	public bool active = false;
	/**How much does this ability cost to activate*/
	public int cost = 0;
}