using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMultiShot : MonoBehaviour {

	public float moveCooldown;
	private float currentTime;
	private Vector3 newPosition;
	private Vector3 startingPosition;
	public float timeBetweenShot;
	public int totalBullets;
	public const int MAX_BULLETS = 3;
	public GameObject bullet;
	private int maxY = 4;
	private int maxX = 12;
	private bool fadeBack;
	private bool shipIsFading;
	List<GameObject> bullets;
	// Use this for initialization
	void Awake(){
		startingPosition = transform.position;
		newPosition = transform.position;
		totalBullets = MAX_BULLETS;
		fadeBack = false;
		shipIsFading = false;
		bullets = new List<GameObject> ();
	}
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, newPosition, 0.25f);
		if(!fadeBack)
		{
			if (currentTime + moveCooldown <= Time.time) {
				LeaveBulletTrail ();
				currentTime = Time.time;
			}
		}else{
			FadeAway ();		
		}
	}

	void LeaveBulletTrail()
	{
		float tempY = newPosition.y + 2;
		if (tempY > maxY) {
			tempY = maxY;
			fadeBack = true;
		}
		newPosition = new Vector3 (transform.position.x, tempY);
		if (Random.Range (0, 100) > 25) {
			if(totalBullets > 0)
			{
				DropBullet();
				totalBullets--;
			}
		}
	}

	void FadeAway(){
		float tempX = newPosition.x + 5;
		if (tempX > maxX) {
			tempX = maxX;
			fadeBack = true;
		}
		newPosition = new Vector3 (tempX, transform.position.y);
		foreach (GameObject bullet in bullets) {
			bullet.GetComponent<Projectile>().speedModifier = 3;
		}
		bullets.Clear ();
		if(!shipIsFading)
		{
			StartCoroutine (Fading());
		}
	}

	IEnumerator Fading()
	{
		Debug.Log ("Waiting...");
		shipIsFading = true;
		yield return new WaitForSeconds (timeBetweenShot);
		fadeBack = false;
		transform.position = startingPosition;
		newPosition = transform.position;
		totalBullets = MAX_BULLETS;
		currentTime = Time.time + (moveCooldown * 0.75f);
		shipIsFading = false;
		//StartCoroutine (FadingIn ());
	}

	IEnumerator FadingIn()
	{	
		if(Random.Range(0, 100) > 50)
		{
			transform.position = new Vector3 (12, -4, 0);
		}else{
			transform.position = new Vector3 (12, 4, 0);
		}

		yield return new WaitForSeconds (timeBetweenShot);

	}

	void DropBullet()
	{
		GameObject bulletClone = Instantiate (bullet, new Vector3 (this.transform.position.x - 0.5f, this.transform.position.y), Quaternion.identity) as GameObject;
		bulletClone.GetComponent<Projectile> ().speedModifier = 0;
		bullets.Add (bulletClone);
	}
}
