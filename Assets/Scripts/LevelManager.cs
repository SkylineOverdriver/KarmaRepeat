using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	/**How long has the level been going*/
	public double levelTime = 0;
	/**How long is the max time for the level*/
	public double levelMaxTime = 0;
	/**How many years of time does this level last*/
	public double levelYearCount = 0;

	/**The battle manager (Used for managing each battle)*/
	public BattleManager battleManager;

	// Use this for initialization
	void Start () 
	{
		GameGlobals.globals.setLevelManager(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
