using UnityEngine;
using System.Collections;

public class WeaponMine : MonoBehaviour
{

	public float mineSpeed;
	public float rotationSpeed;
	// Use this for initialization
	void Start ()
	{
		Physics2D.IgnoreLayerCollision (8, 9, true);
		if (GameStats.instance.GetBossMode ())
						mineSpeed *= -1;
		rigidbody2D.velocity = new Vector2 (mineSpeed, 0);
	}

	// Update is called once per frame
	void Update ()
	{
		transform.rigidbody2D.rotation -= rotationSpeed;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "BreakableRock") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (other.tag == "HardRock") {
			Destroy (gameObject);
		}
		if (other.tag == "Enemy") {
			Destroy(gameObject);
			Destroy(other.gameObject);
		}	
		if (other.tag == "Boss01") {
			Destroy(gameObject);
			other.GetComponent<Boss01>().TakeDamage(1);
				}
	}
}
