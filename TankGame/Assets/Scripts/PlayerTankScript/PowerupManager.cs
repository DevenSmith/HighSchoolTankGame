using UnityEngine;
using System.Collections;

public class PowerupManager : MonoBehaviour 
{
	TankShooting tShooting;
	public string spreadShotTag = "SpreadPowerUp";

	void Start()
	{
		tShooting = gameObject.GetComponent<TankShooting>();
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == spreadShotTag)
		{
			Destroy(c.gameObject);
			tShooting.SetupSpreadShot();
			//tell tank shooting to be spreadshot
		}
	}
}
