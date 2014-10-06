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

		// Use this for initialization
		protected virtual void Start ()
		{
				playerTransform = PlayerController.player.transform;
		}
	
		// Update is called once per frame
		protected virtual void Update ()
		{				
				distance = Vector3.Distance (this.transform.position, playerTransform.position);				
				ProximityPickup ();	
		}

		protected virtual void PickedUp()
		{				
				Destroy (gameObject);
		}

		void ProximityPickup ()
		{

				if (distance < GameStats.instance.GetPickupDistance() && !triggered) {
						position = transform.position;
						triggered = true;
				}
				if (triggered) {
						transform.position = Vector3.Lerp (position, playerTransform.position, collectSpeed);
						transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (0.1f, 0.1f, 0.1f), 0.05f);
						collectSpeed += Time.deltaTime;
						if (distance < 0.1f) {
								PickedUp();
						}

				}
		}

		
}
