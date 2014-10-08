using UnityEngine;
using System.Collections;

public class EnemySimpleShot : Enemy {

	public float shotCooldown;
	private float currentTime;
	public GameObject bullet;

	// Use this for initialization
	public virtual void Start () {
		currentTime = Time.time;
	}
	
	// Update is called once per frame
	public override void Update () {
		if (currentTime + shotCooldown <= Time.time) {
			Fire ();
			currentTime = Time.time;
		}
		base.Update ();
	}

	public virtual void Fire(){
		GameObject bulletClone = Instantiate (bullet, new Vector3 (this.transform.position.x - 0.5f, this.transform.position.y), Quaternion.identity) as GameObject;
	}
}
