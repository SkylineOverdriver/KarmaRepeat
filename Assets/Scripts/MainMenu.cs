using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/**Makes the game jump to a scene*/
	public void goToScene(string name)
	{
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		SceneManager.LoadSceneAsync(name);

	}
		
	/**Exits the game*/
	public void exitGame()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
