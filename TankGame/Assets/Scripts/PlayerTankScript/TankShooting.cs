using UnityEngine;
using System.Collections;

public class TankShooting : MonoBehaviour 
{
	public GameObject barrelGameObject;
	public GameObject bulletPrefab;
	public float fireForce;
	public float shotsPerSecond;
	bool isBasicShot = true;
	float fireDelay;
	float curFireDelay;

	bool isSpreadShot = false;
	public int shotsInSpread = 5;
	public int timesSpreadCanBeShot = 10;
	int spreadShots = 0;
	public float horizontalSpread = 45;
	public float verticalSpread = 45;
	public float spreadShotTimeLimit = 10.0f;
	float curSpreadShotTime = 0.0f;

	bool stoppedShooting = true;

	void Start()
	{
		fireDelay = 1.0f / shotsPerSecond;
	}
	
	// Update is called once per frame
	void Update () 
	{
		curFireDelay += Time.deltaTime;
		if(Input.GetAxisRaw("Jump") == 0)
			stoppedShooting = true;


		if(curSpreadShotTime > 0)
		{
			curSpreadShotTime -= Time.deltaTime;
			if(curSpreadShotTime <= 0)
			{
				isSpreadShot = false;
				isBasicShot = true;
			}
		}
		if(isSpreadShot && spreadShots <= 0)
		{
			isSpreadShot = false;
			isBasicShot = true;
		}

		if(Input.GetAxisRaw("Jump") > 0 && curFireDelay >= fireDelay)
		{

			if(isBasicShot)
			{
				stoppedShooting = false;
				BasicShot();
			}
		}

		if(Input.GetAxisRaw("Jump") > 0 && stoppedShooting)
		{
			if(isSpreadShot && curSpreadShotTime > 0 
			   && spreadShots > 0)
			{
				stoppedShooting = false;
				SpreadShot();
			}
		}
	}

	public void BasicShot()
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

	public void SpreadShot()
	{
		spreadShots--;
		GameObject[] bullets = new GameObject[shotsInSpread];
		for(int i = 0; i < shotsInSpread; i++)
		{
			float horSpread = Random.Range(-horizontalSpread, horizontalSpread);
			float verSpread = Random.Range(-verticalSpread, verticalSpread);

			Vector3 t;
			//t.rotation = transform.rotation;
			t = new Vector3(transform.eulerAngles.x + horSpread,
			                transform.eulerAngles.y + verSpread,
			                transform.eulerAngles.z);
			bulletPrefab.transform.eulerAngles = t;


			bullets[i] = (GameObject) Instantiate(
				bulletPrefab, 
				barrelGameObject.transform.position,
				bulletPrefab.transform.rotation); 
			bullets[i].rigidbody.AddForce(fireForce*bullets[i].transform.forward,
			                          ForceMode.Impulse);
			bulletPrefab.transform.eulerAngles = Vector3.zero;
		}
	}

	public void SetupSpreadShot()
	{
		isBasicShot = false;
		isSpreadShot = true;
		curSpreadShotTime = spreadShotTimeLimit;
		spreadShots = timesSpreadCanBeShot;
	}
}
