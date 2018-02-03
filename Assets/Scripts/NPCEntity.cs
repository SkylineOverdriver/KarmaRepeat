using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEntity : CharacterEntity 
{
	/**The lines which this NPC can say*/
	public List<string> dialogueLines = new List<string>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**Returns a random dialogue line for this character to say*/
	public virtual string getDialogueLine()
	{
		if(dialogueLines.Count > 0)
			return dialogueLines[Random.Range(0, dialogueLines.Count)];
		else
			return "...";
	}
}
