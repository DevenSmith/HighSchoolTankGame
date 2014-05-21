using UnityEngine;
using System.Collections;

public class EnemyWanderScript : MonoBehaviour 
{

	public float moveSpeed = 3.0f;
	public float rotationSpeed = 45.0f;
	public float minWanderTime = 2.0f;
	public float maxWanderTime = 5.0f;
	float wanderTime = 2.5f;
	Quaternion newRotation;

	// Use this for initialization
	void Start () 
	{
		newRotation.eulerAngles += new Vector3 (0, Random.Range(0, 360), 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(wanderTime <= 0.0f)
		{
			transform.localRotation = Quaternion.Slerp
				(transform.localRotation, newRotation , Time.deltaTime * rotationSpeed);
			wanderTime = Random.Range(minWanderTime, maxWanderTime);
			newRotation.eulerAngles += new Vector3 (0, Random.Range(0, 360), 0);
		}
		else
		{
			transform.Translate
				(transform.forward * moveSpeed * Time.deltaTime, Space.World);
			wanderTime -= Time.deltaTime;
		}
	}
}
