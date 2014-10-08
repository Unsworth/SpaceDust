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
		}
}
