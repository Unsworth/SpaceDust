using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{

		Transform playerTransform;
		float distance;
		bool triggered = false;
		float collectSpeed = 0.01f;
		Vector3 position;
		Vector3 scale;
		float currentSpeed;

		// Use this for initialization
		protected virtual void Start ()
		{
				playerTransform = PlayerController.player.transform;
				currentSpeed = GameStats.instance.GetCurrentSpeed ();
				rigidbody2D.velocity = new Vector2 (GameStats.instance.GetCurrentSpeed () * -1, 0);
		}
	
		// Update is called once per frame
		protected virtual void Update ()
		{				
				distance = Vector3.Distance (this.transform.position, playerTransform.position);
				if (!triggered) {
					if (currentSpeed != GameStats.instance.GetCurrentSpeed ())
			{
						rigidbody2D.velocity = new Vector2 (GameStats.instance.GetCurrentSpeed () * -1, 0);
						currentSpeed = GameStats.instance.GetCurrentSpeed ();
			}
				}
				ProximityPickup ();	
		}

		protected virtual void PickedUp ()
		{				
				Destroy (gameObject);
		}

		void ProximityPickup ()
		{

				if (distance < GameStats.instance.GetPickupDistance () && !triggered) {
						position = transform.position;
						triggered = true;
				}
				if (triggered) {
						transform.position = Vector3.Lerp (position, playerTransform.position, collectSpeed);
						transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (0.1f, 0.1f, 0.1f), 0.05f);
						collectSpeed += Time.deltaTime;
						if (distance < 0.1f) {
								PickedUp ();
						}

				}
		}

		
}
