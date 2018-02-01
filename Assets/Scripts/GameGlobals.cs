using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGlobals : MonoBehaviour 
{
	/**Access to the game globals*/
	public static GameGlobals globals = null;

	/**The key code that makes the player move left*/
	public static KeyCode moveLeftKey = KeyCode.LeftArrow;
	/**The key code that makes the player move right*/
	public static KeyCode moveRightKey = KeyCode.RightArrow;
	/**The key code that makes the player jump*/
	public static KeyCode moveJumpKey = KeyCode.Space;
	/**The key codes to make the player use items*/
	public static KeyCode[] toolbarKeys = new KeyCode[7]{KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M};
	/**The key code to open an inventory*/
	public static KeyCode inventoryKey = KeyCode.A;
	/**The key code to make the toolbar move up a slot*/
	public static KeyCode toolbarUpKey = KeyCode.UpArrow;
	/**The key code to make the toolbar move down a slot*/
	public static KeyCode toolbarDownKey = KeyCode.DownArrow;

	/**The current level manager which is loaded*/
	public LevelManager level;

	public void Start()
	{
		
		//Prevent multiple of this gameobject from being created whenever the menu is accessed
		if(globals == null)
		{
			//Keep this object throughout the entire game
			DontDestroyOnLoad(this.gameObject);
			globals = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
			

	/**Loads a new level*/
	public bool loadLevel(string name)
	{
		try
		{
			if(SceneManager.GetActiveScene().name.Equals(name))
				Debug.LogWarning("Loaded same level as was open!, Use reloadLevel to do this!");
			SceneManager.LoadScene(name);
			return true;
		}
		catch(System.Exception e)
		{
			Debug.Log(e.ToString());
			return false;
		}

	}

	/**Re loads the current level*/
	public bool reloadLevel()
	{
		Debug.LogError("Unimplemented!");
		return false;
	}

	/**Sets the current level manager*/
	public void setLevelManager(LevelManager manager)
	{
		if(level.Equals(manager))
			Debug.LogWarning("Tried to set new level manager to itsself!");
		level = manager;
	}
}
