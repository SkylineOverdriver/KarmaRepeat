using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour 
{
	/**The amount of times this destructable can be hit*/
	public int health = 1;
	/**How much health can this destructable have*/
	public int maxHealth = 1;
	/**The objects which spawn when this object is destroyed*/
	public GameObject[] drops;
	/**How many objects should drop when this object is broken*/
	public int dropCount = 1;

	/**Damages the destructable*/
	public void damage(int amount)
	{
		health -= amount;
		if(health <= 0)
			breakObject();	
	}

	/**Repairs the destructable*/
	public void repair(int amount)
	{
		health += amount;
		if(health >= maxHealth)
			health = maxHealth;
	}

	/**Called when this destructable is broken*/
	public void breakObject()
	{
		//TODO: Add debris dropping code
		for(int i = 0; i < dropCount; i++)
		{
			Instantiate(drops[Random.Range(0, drops.GetLength(0))], this.transform.position, this.transform.rotation);
		}
		Destroy(this.gameObject);
	}
}
