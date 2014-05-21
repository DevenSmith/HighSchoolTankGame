using UnityEngine;
using System.Collections;

public class  GameManager 
{
	public static int enemyType1Killed = 0;
	public static int enemyType2Killed = 0;

	public static int enemy1Value = 10;
	public static int enemy2Value = 50;

	public static int totalEnemiesKilled = 0;
	public static int score = 0;

	public void EnemyType1Killed()
	{
		enemyType1Killed++;
		totalEnemiesKilled++;
		score += enemy1Value;
	}

	public void EnemyType2Killed()
	{
		enemyType2Killed++;
		totalEnemiesKilled++;
		score += enemy2Value;
	}

}
