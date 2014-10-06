using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{

		Transform playerTransform;
		float distance;
		bool triggered = false;
		float collectSpeed = 0.1f;

		// Use this for initialization
		void Start ()
		{
				playerTransform = PlayerController.player.transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
				distance = Vector3.Distance (this.transform.position, playerTransform.position);
				transform.Rotate (0.0f, 0.0f, 10.0f * Time.deltaTime);
				ProximityPickup ();
	
		}

		void ProximityPickup ()
		{
				if (distance < 1.5f) {
						triggered = true;
				}
				if (triggered) {
						transform.position = Vector3.Lerp (transform.position, playerTransform.position, collectSpeed);
						transform.localScale = Vector3.Lerp (transform.localScale, new Vector3 (0.1f, 0.1f, 0.1f), 0.05f);
						collectSpeed += Time.deltaTime;
						if (distance < 0.1f) {
								UIManager.instance.SetScore (25);
								Destroy (gameObject);
						}

				}
		}
}
