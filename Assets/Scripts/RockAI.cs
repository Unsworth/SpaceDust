﻿using UnityEngine;
using System.Collections;

public class RockAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -10)
		{
			UIManager.instance.SetScore(10);
			Destroy(gameObject);
		}
	}
}
