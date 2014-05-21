using UnityEngine;
using System.Collections;

public class TankShooting : MonoBehaviour 
{
	public GameObject barrelGameObject;
	public GameObject bulletPrefab;
	public float fireForce;
	public float shotsPerSecond;
	float fireDelay;
	float curFireDelay;

	void Start()
	{
		fireDelay = 1.0f / shotsPerSecond;
	}
	
	// Update is called once per frame
	void Update () 
	{
		curFireDelay += Time.deltaTime;

		if(Input.GetAxisRaw("Jump") > 0 && curFireDelay >= fireDelay)
		{
			curFireDelay = 0.0f;
			GameObject bullet;
			bullet = (GameObject) Instantiate(
				bulletPrefab, 
				barrelGameObject.transform.position,
				transform.rotation); 
			bullet.rigidbody.AddForce(fireForce*bullet.transform.forward,
			                          ForceMode.Impulse);
		}
	}
}
