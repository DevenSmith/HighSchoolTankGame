using UnityEngine;
using System.Collections;

public class ScoreGUITextScript : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		guiText.text = "Player Score : " + GameManager.score
			+ "\nBombBugsKilled : " + GameManager.bombBugKilledThisLevel
				+ "\nShootingBugKilled : " + GameManager.shootingEnemyKilledThisLevel;
	}
}
