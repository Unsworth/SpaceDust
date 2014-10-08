﻿using UnityEngine;
using System.Collections;

public class EnemyLaneJumper : Enemy
{

	public float moveCooldown;
	private float currentTime;
	private GameObject player;
	private Vector3 newPosition;
	public float maxSpeed;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		newPosition = transform.position;
		maxSpeed = speedModifier * 4;
	}

	// Update is called once per frame
	void Update ()
	{
		base.Update ();
		transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y, newPosition.y, 0.1f), 0);
		if(transform.position.x > Camera.main.transform.position.x)
		{
			if (currentTime + moveCooldown <= Time.time) {
				float absY = Mathf.Abs (player.rigidbody2D.position.y - rigidbody2D.position.y);
				if (absY > 1.75f) {
					if(player.rigidbody2D.position.y > rigidbody2D.position.y)
					{
						newPosition = new Vector3(transform.position.x, newPosition.y + 2);//new Vector2 (rigidbody2D.position.x, rigidbody2D.position.y + 2);
					} else {
						newPosition = new Vector3(transform.position.x, newPosition.y - 2);
					}
				}
				currentTime = Time.time;
			}
		}else{
			if(currentSpeed != maxSpeed)
			{
				GetComponent<SpriteRenderer>().color = Color.red;
				currentSpeed = maxSpeed;
				speedModifier = maxSpeed;
			}
		}
	}
}
