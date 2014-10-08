using UnityEngine;
using System.Collections;

public class ProjectileDirect : Projectile {

	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Vector2 norm = (player.gameObject.rigidbody2D.position - gameObject.rigidbody2D.position).normalized;
		rigidbody2D.velocity = new Vector2 (norm.x * 4, norm.y * 4);
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}
}
