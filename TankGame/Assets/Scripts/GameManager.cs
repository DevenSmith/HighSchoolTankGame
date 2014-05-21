using UnityEngine;
using System.Collections;

public class  GameManager : MonoBehaviour 
{
	public static int bombBugKilledThisLevel = 0;
	public static int shootingEnemyKilledThisLevel = 0;
	public static int bombBugKilledLifeTime = 0;
	public static int shootingEnemyKilledLifeTime = 0;

	public static int bombBugValue = 10;
	public static int shootingEnemyValue = 50;

	public static int totalEnemiesKilled = 0;
	public static int score = 0;

	public void BombBugKilled()
	{
		bombBugKilledThisLevel++;
		bombBugKilledLifeTime++;
		totalEnemiesKilled++;
		score += bombBugValue;
	}

	public void ShootingEnemyKilled()
	{
		shootingEnemyKilledThisLevel++;
		shootingEnemyKilledLifeTime++;
		totalEnemiesKilled++;
		score += shootingEnemyValue;
	}

	public static void Reset()
	{
		bombBugKilledLifeTime = 0;
		shootingEnemyKilledLifeTime = 0;
		score = 0;
		totalEnemiesKilled = 0;
		bombBugKilledThisLevel = 0;
		shootingEnemyKilledThisLevel = 0;
	}

	public static void LevelReset()
	{
		bombBugKilledThisLevel = 0;
		shootingEnemyKilledThisLevel = 0;
	}
}
