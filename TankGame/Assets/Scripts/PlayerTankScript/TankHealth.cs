using UnityEngine;
using System.Collections;

public class TankHealth : MonoBehaviour 
{
	public static int lives = 3;
	public int health = 100;
	public int armour = 0;
	public string restartLevelName = "main";

	public void Hurt(int damage)
	{
		if(damage > armour)
		{
			health -= damage - armour;

			if(health <= 0)
			{
				Die();
			}
		}
	}

	public void Die()
	{
		if(lives > 1)
		{
			lives--;
			GameManager.LevelReset();
			Application.LoadLevel(Application.loadedLevel);
		}
		else
		{
			lives = 3;
			GameManager.Reset();
			Application.LoadLevel(restartLevelName);
		}
	}
}
