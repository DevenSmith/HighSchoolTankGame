using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour 
{
	public int damage = 25;
	public float destroyTime  = 5.0f;
	public float curLifeTime = 0.0f;
	
	// Update is called once per frame
	void Update () 
	{
		curLifeTime += Time.deltaTime;
		if(curLifeTime > destroyTime)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Enemy")
		{
			c.gameObject.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver );
		}
	}
}
