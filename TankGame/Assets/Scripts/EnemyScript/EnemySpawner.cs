using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{

	public GameObject enemyPrefab;
	public float xSpawnZone = 5.0f;
	public float zSpawnZone = 5.0f;
	public float maxSpawnTime = 10.0f;
	public float minSpawnTime = 5.0f;
	float curSpawnTime = 0.0f;

	// Use this for initialization
	void Start () 
	{
		curSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		curSpawnTime -= Time.deltaTime;
		if(curSpawnTime <= 0)
		{
			float xSpawnPoint = Random.Range(-xSpawnZone, xSpawnZone);
			float zSpawnPoint = Random.Range(-zSpawnZone, zSpawnZone);
			Vector3 spawnPoint = new Vector3(transform.position.x + xSpawnPoint, 
			                                 transform.position.y,
			                                 transform.position.z + zSpawnPoint);
			Instantiate(enemyPrefab, spawnPoint, transform.rotation);
			curSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
		}
	}
}
