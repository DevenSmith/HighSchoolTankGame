using UnityEngine;
using System.Collections;

public class EnemyHealthBarScript : MonoBehaviour 
{
	GameObject player;
	public EnemyScript enemyScript;
	int baseHealth;
	int healthPercent;
	// Use this for initialization
	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		baseHealth = enemyScript.health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthPercent = enemyScript.health / baseHealth;

		transform.localScale = new Vector3(healthPercent , transform.localScale.y, transform.localScale.z);
		transform.LookAt(player.transform.position);
	}
}
