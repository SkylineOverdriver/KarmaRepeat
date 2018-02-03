using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : CharacterEntity {

	/**The player's karma, this is 150 at start*/
	public int karma = 150;
	/**The player's true karma, this is a measure of how consistent they are (Total between all runs)*/
	public int trueKarma = 0;

	/**The player's age (in years)*/
	public float playerLifespan = 0;
	/**The tick in years which the player's life progresses*/
	public float playerLifespanTickTime = 0.001f;

	/**Is the player in their (or someone else's) inventory*/
	public bool inInventory = false;

	/**The rigidbody on the player*/
	private Rigidbody2D playerRigidbody;

	/**The movement speed of the player*/
	public float moveSpeed
	{
		get
		{
			return _moveSpeed;
		}
		set
		{
			_moveSpeed = value;
			moveLeftVector.Set(-value, 0);
			moveRightVector.Set(value, 0);
		}
	}

	/**The jump force of the player*/
	public float jumpForce
	{
		get
		{
			return _jumpForce;
		}
		set
		{
			_jumpForce = value;
			jumpForceVector.Set(0, value);
		}
	}
		
	[SerializeField]
	/**The speed the player moves*/
	private float _moveSpeed = 0.01f;
	[SerializeField]
	/**The force of the player's jump*/
	private float _jumpForce = 200;

	/**The vector for moving left*/
	public Vector2 moveLeftVector = new Vector2(-0.01f, 0.0f);
	/**The vector for moving right*/
	public Vector2 moveRightVector = new Vector2(0.01f, 0.0f);
	/**The vector for jumping*/
	public Vector2 jumpForceVector = new Vector2(0.0f, 200f);

	/**The key code that makes the player move left*
	public KeyCode moveLeftKey = KeyCode.LeftArrow;
	/**The key code that makes the player move right*
	public KeyCode moveRightKey = KeyCode.RightArrow;
	/**The key code that makes the player jump*
	public KeyCode moveJumpKey = KeyCode.Space;
	/**The key codes to make the player use items*
	public KeyCode[] itemSlotKeys = new KeyCode[7]{KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M};
	/**The key code to open an inventory*
	public KeyCode inventoryKey = KeyCode.A;

	/**Can the player jump?*/
	public bool canJump = false;
	/**Is the player currently jumping*/
	public bool isJumping = false;

	// Use this for initialization
	public override void Start () 
	{
		base.Start();
		playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerLifespan += playerLifespanTickTime;

		if(Input.GetKeyDown(GameGlobals.moveJumpKey))
		{
			isJumping = true;
		}
	}

	//Called for every physics update (can be called twice or more per frame)
	void FixedUpdate()
	{
		if(!inInventory)
		{
			if(Input.GetKey(GameGlobals.moveLeftKey))
			{
				playerRigidbody.AddForce(moveLeftVector);
			}
			else if(Input.GetKey(GameGlobals.moveRightKey))
			{
				playerRigidbody.AddForce(moveRightVector);
			}

			if(isJumping && canJump)
			{
				playerRigidbody.AddForce(jumpForceVector);
				canJump = false;
				isJumping = false;
			}
		}
	}


	//PROBLEM: Any side of the player can touch the ground (Collision check instead of trigger)
	//SOLUTIONS:
	//1. Make the player have a trigger underneath them
	//2. Make the player check the surrounding area for the ground (more computation)
	//3. Make the player use a physics calculation for jumping


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Ground"))
		{
			canJump = true;
		}
	}

	void OnTriggerExitr2D(Collider2D other)
	{
		if(other.CompareTag("Ground"))
		{
			canJump = false;
		}
	}
}
