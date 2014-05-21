using UnityEngine;
using System.Collections;

public class PlayerLivesGuiText : MonoBehaviour 
{

	void Update () 
	{
		guiText.text = "Lives : " + TankHealth.lives;
	}
}
