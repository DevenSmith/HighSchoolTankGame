using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour 
{
	public int bombBugsToKill = 0;
	public int enemyType2ToKill = 0;

	public string nextLevelName = "";

	// Use this for initialization
	void Start () 
	{
		GameManager.bombBugKilledThisLevel = 0;
		GameManager.shootingEnemyKilledThisLevel = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.bombBugKilledThisLevel >= bombBugsToKill
		    && GameManager.shootingEnemyKilledThisLevel >= enemyType2ToKill)
		{
			Application.LoadLevel(nextLevelName);
		}
	}
}
