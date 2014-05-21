using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public int health;
	public int armour;


	public void Hurt(int damage)
	{
		if(damage > armour)
		{
			health -= damage - armour;
			if(health <= 0)
				Destroy(gameObject);
		}
	}
}
