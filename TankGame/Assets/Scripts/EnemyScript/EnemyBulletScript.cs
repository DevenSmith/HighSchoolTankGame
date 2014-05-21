using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour 
{
	public int damage = 10;
	public float lifeTime = 3.0f;
	public float fireForce = 10;

	// Use this for initialization
	void Start () 
	{
		rigidbody.AddForce(transform.forward * fireForce, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () 
	{
		lifeTime -= Time.deltaTime;
		if(lifeTime <= 0.0f)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision c)
	{
		if(c.gameObject.tag == "Player")
		{
			c.gameObject.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
