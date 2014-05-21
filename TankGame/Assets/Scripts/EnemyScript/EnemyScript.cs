using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public GameManager gameManagerScript;
	public int health;
	public int armour;

	void Start()
	{
		GameObject gameManagerObject;
		gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
		gameManagerScript = gameManagerObject.GetComponent<GameManager>();
	}


	public virtual void Hurt(int damage)
	{
		if(damage > armour)
		{
			health -= damage - armour;
			if(health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
