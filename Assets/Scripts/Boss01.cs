using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Boss01. Idea #78: LaneJumper boss: Lure it into rocks to damage it
/// </summary>
public class Boss01 : MonoBehaviour
{

	public int healthMax = 10;
	public int healthCurrent = 10;
	public float speed;
	public float attackRate = 2.0f;
	public float attackTime;
	Vector3 beginningPosition;
	Vector3 attackPosition = new Vector3 (-7.5f, 0, 0);
	int[] lanes = new int[5]{-4, -2, 0, 2, 4};
	public List<GameObject> cannons;
	int targetLane = 2;
	Transform player;
	public GameObject bullet;
	bool waveMode;

	public enum AttackMode
	{
		entering,
		regular,
		wave,
		wall,
	}

	AttackMode mode;


	// Use this for initialization
	void Awake ()
	{
		mode = AttackMode.entering;
		beginningPosition = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (healthCurrent < 0) {
			Destroy(gameObject);
		}
		switch (mode) {
		case AttackMode.entering:
		{
			transform.position = Vector3.Lerp (transform.position, attackPosition, 0.01f);
			if (Mathf.Abs (Vector3.Distance (transform.position, attackPosition)) < 0.1f) {
				transform.position = attackPosition;
				attackTime = Time.time + attackRate;
				mode = AttackMode.wave;
			}
			break;
		}
		case AttackMode.regular:
		{
			RegularAttack ();
			if (healthCurrent < healthMax / 2)
				mode = AttackMode.wave;
			break;
		}
		case AttackMode.wall:
		{
			break;
		}
		case AttackMode.wave:
		{
			WaveAttack ();
			break;
		}
		}
	}

	void RegularAttack ()
	{
		if (attackTime < (Time.time)) {
			FireBullet (Random.Range (0, 4));
			attackTime = Time.time + attackRate;
		}
	}

	void WaveAttack ()
	{
		if (attackTime < (Time.time)) {
			int doNotAttackLane = Random.Range (0, 5);
			Debug.Log ("Wave Mode: " +waveMode +"  ||  Do Not Attack Lane: " +doNotAttackLane);
			int j = 0;
			if (waveMode) {
				for (int i = 0; i < 5; i++) {
					if (i == doNotAttackLane)
						continue;
					StartCoroutine (FireInSeconds (0.25f * i + 0.25f, i));
				}
			} else if (!waveMode) {
				for (int i = 4; i >= 0; i--) {
					if (i == doNotAttackLane)
						continue;
					StartCoroutine (FireInSeconds (0.25f * i + 0.25f, j));
					j++;
				}
			}
			waveMode = !waveMode;
			attackTime = Time.time + attackRate * 2;
		}
	}

	void FireBullet (int yPosition)
	{
		GameObject bulletClone = Instantiate (bullet, new Vector3 (transform.position.x, lanes [yPosition], 0), Quaternion.identity) as GameObject;
		bulletClone.GetComponent<Projectile> ().speedModifier = -1;
	}

	IEnumerator FireInSeconds (float time, int lane)
	{		
		cannons [lane].GetComponent<SpriteEffects> ().StartFlicker ();
		yield return new WaitForSeconds (time);
		FireBullet (lane);		
	}

	public void TakeDamage(int damage)
	{
	healthCurrent -= damage;
	}
}
