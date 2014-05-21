using UnityEngine;
using System.Collections;

public class EnemyHealthBarScript : MonoBehaviour 
{
	GameObject player;
	public EnemyScript enemyScript;
	public int baseHealth = 0;
	public float healthPercent = 0;
	int previousHealth = 0;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("MainCamera");
		baseHealth = enemyScript.health;
		previousHealth= baseHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemyScript.health != previousHealth)
		{
			healthPercent = (float)enemyScript.health / (float)baseHealth;
			transform.localScale = new Vector3(healthPercent , transform.localScale.y, transform.localScale.z);
		}

		transform.LookAt(player.transform.position);
	}
}
