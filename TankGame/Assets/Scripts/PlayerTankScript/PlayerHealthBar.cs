using UnityEngine;
using System.Collections;

public class PlayerHealthBar : MonoBehaviour 
{
	TankHealth tankHealth;
	GameObject player;
	float maxHealth;
	float curHealthPercent;
	Transform myTransform;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		tankHealth = player.GetComponent<TankHealth>();
		maxHealth = tankHealth.health;
		curHealthPercent = 1;// on a scale of 0 to 1
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(curHealthPercent != tankHealth.health/maxHealth)
		{
			curHealthPercent = tankHealth.health/maxHealth;
			myTransform.localScale = new Vector3(curHealthPercent, 
			                                     myTransform.localScale.y,
			                                     myTransform.localScale.z);
		}
	}
}
