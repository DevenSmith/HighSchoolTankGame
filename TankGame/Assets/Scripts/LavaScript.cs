using UnityEngine;
using System.Collections;

public class LavaScript : MonoBehaviour 
{
	public int damage;
	public float damageInterval;
	float curDamageInterval;
	bool damagingPlayer = false;

	void Start()
	{
		curDamageInterval = damageInterval;
	}

	void Update () 
	{
		if(damagingPlayer)
			curDamageInterval -= Time.deltaTime;
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			damagingPlayer = true;
			c.gameObject.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			curDamageInterval = damageInterval;
		}
	}

	void OnTriggerStay(Collider c)
	{

		if( c.tag == "Player" && curDamageInterval <= 0)
		{
			c.gameObject.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			curDamageInterval = damageInterval;
		}
	}

	void OnTriggerExit(Collider c)
	{
		if(c.tag == "Player")
		{
			damagingPlayer = false;
			curDamageInterval = damageInterval;
		}
	}
}
