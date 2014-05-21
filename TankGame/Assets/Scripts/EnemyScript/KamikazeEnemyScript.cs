using UnityEngine;
using System.Collections;

public class KamikazeEnemyScript : EnemyScript 
{	
	public void OnDestroy()
	{
		if(health <= 0)
			gameManagerScript.BombBugKilled();
	}
}
