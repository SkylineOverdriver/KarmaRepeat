using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	/**The player's karma, this is zero at start*/
	public int karma = 0;
	/**The player's true karma, this is a measure of how consistent they are*/
	public int trueKarma = 0;

	/**The player's current health*/
	public float health = 0;
	/**The player's maximum health*/
	public float maxHealth = 0;

	/**The player's age (in years)*/
	public float playerLifespan = 0;
	/**The tick in years which the player's life progresses*/
	public float playerLifespanTickTime = 0.001f;

	public KeyCode moveLeftKey = KeyCode.A;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerLifespan += playerLifespanTickTime;
	}
}
