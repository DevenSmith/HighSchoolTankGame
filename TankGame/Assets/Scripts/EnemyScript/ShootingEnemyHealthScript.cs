using UnityEngine;
using System.Collections;

public class ShootingEnemyHealthScript : EnemyScript 
{
	public void OnDestroy()
	{
		if(health <= 0)
			gameManagerScript.ShootingEnemyKilled();
	}
}
