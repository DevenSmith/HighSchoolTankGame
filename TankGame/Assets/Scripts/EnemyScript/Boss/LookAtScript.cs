﻿using UnityEngine;
using System.Collections;

public class LookAtScript : MonoBehaviour 
{
	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(player.transform);
	}
}
