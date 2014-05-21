using UnityEngine;
using System.Collections;

public class ShootingEnemyScript : MonoBehaviour 
{
	public EnemyWanderScript wanderscript;
	public float radarDistance = 10.0f;
	bool playerFound = false;
	GameObject player;
	public float strength = 0.5f;

	public GameObject barrel;
	public GameObject bulletPrefab;
	public float shotsPerSecond;
	float shotDelay;
	float curShotDelay;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		shotDelay = 1.0f/shotsPerSecond;
		curShotDelay = shotDelay;
	}

	void Update () 
	{
		if(Vector3.Distance(player.transform.position, transform.position)
		    <= radarDistance)
		{
			if(!playerFound)
			{
				playerFound = true;
				wanderscript.enabled = false;
			}
		}
		else
		{
			if(playerFound)
			{
				curShotDelay = shotDelay;
				playerFound = false;
				wanderscript.enabled = true;
				transform.eulerAngles = new Vector3(0, transform.eulerAngles.y,  0);
			}
		}

		if(playerFound)
		{
			Quaternion targetRotation = Quaternion.LookRotation
				(player.transform.position - transform.position);
			float str = Mathf.Min(strength * Time.deltaTime, 1);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
		

			curShotDelay -= Time.deltaTime;
			if(curShotDelay <= 0)
			{
				Instantiate(bulletPrefab, barrel.transform.position, barrel.transform.rotation);
				curShotDelay = shotDelay;
			}
		}
	}
}
