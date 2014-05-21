using UnityEngine;
using System.Collections;

public class EnemyKamikazeAttack : MonoBehaviour 
{
	public int damage = 100;

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Player")
		{
			c.gameObject.SendMessage("Hurt",
			                         damage,
			                         SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

}
