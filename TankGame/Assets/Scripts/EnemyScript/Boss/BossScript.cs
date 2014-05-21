using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour 
{
	//needs to spin and shoot
	public float jumpForce = 10000;
	bool jump = false;// says if I am in jump Attack mode
	bool jumped = false;// says wether I have left Ground yet
	bool touchedDown = false;
	bool shooting = false;
	public float spinRate = 360;
	public float pushForce = 100;
	public GameObject bulletPrefab;
	public float checkForGroundTime = 2.0f;
	float curCheckForGround;
	public float fireRate = 1.0f;
	float fireTime;
	float curFireTime;
	public float spinTime = 5.0f;
	float curSpinTime = 0.0f;
	public float waitTime = 3.0f;
	float curWaitTime = 0.0f;
	public GameObject[] turrets;

	// Use this for initialization
	void Start () 
	{
		curSpinTime = spinTime;
		curWaitTime = waitTime;
		fireTime = 1.0f / fireRate;
		curFireTime = fireTime;
		curCheckForGround = checkForGroundTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(curWaitTime > 0)
		{
			curWaitTime -= Time.deltaTime;
			if(curWaitTime <= 0)
			{
				int random = Random.Range(0,2);
				if(random == 0)
					jump = true;
				else if( random == 1)
					shooting = true;
			}
		}

		if(jump)
			Jump();

		if(shooting)
		{
			Shooting();
		}
	}

	public void Jump()
	{
		if(!jumped)
		{
			rigidbody.AddForce(transform.up * jumpForce,
			                   ForceMode.VelocityChange);
			jumped = true;
		}

		if(jumped)
		{
			if(curCheckForGround > 0)
				curCheckForGround -= Time.deltaTime;
		}

		if(touchedDown)
		{
			jump = false;
			jumped = false;
			touchedDown = false;
			curWaitTime = waitTime;
			curCheckForGround = checkForGroundTime; 
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			Vector3 pushAwayVector = player.transform.position
				- new Vector3(transform.position.x,
				              player.transform.position.y,
				              transform.position.z);
			player.rigidbody.AddForce(pushAwayVector.normalized * pushForce,
			                          ForceMode.VelocityChange);
		}
	}

	public void Shooting()
	{
		curSpinTime -= Time.deltaTime;
		if(curSpinTime <= 0)
		{
			curSpinTime = spinTime;
			shooting = false;
			curFireTime = fireTime;
			curWaitTime = waitTime;
		}

		transform.RotateAround(transform.position,
		                       transform.up,
		                       spinRate * Time.deltaTime);
		curFireTime -= Time.deltaTime;
		if(curFireTime <= 0)
		{
			foreach(GameObject g in turrets)
			{
				Instantiate(bulletPrefab,
				            g.transform.position,
				            g.transform.rotation);
			}
			curFireTime = fireTime;
		}

	}

	void OnCollisionStay(Collision c)
	{
		if(c.gameObject.tag == "Ground")
			if(curCheckForGround <= 0 && !touchedDown && jump)
				touchedDown = true;
	}
}
