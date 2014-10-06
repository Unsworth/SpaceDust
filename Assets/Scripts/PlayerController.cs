using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
		public GameObject mineBullet;
		public static PlayerController player;
		SpriteEffects spriteEffects;
		float screenMiddleWidth = Screen.width / 2;

		int maxY = 4;
		int minY = -4;
		float maxX = 0.5f;
		float minX = -9.5f;
		float newY;
		float newX;
		float baseX;
		Vector3 currentPosition;
		Vector3 newPosition;
		bool hit;
		bool canShoot; 
		public float timeBetweenShot;

		void Awake ()
		{
				if (player != null)
						GameObject.Destroy (player);
				else
						player = this;
		
				DontDestroyOnLoad (player);
		}


		// Use this for initialization
		void Start ()
		{
				player = this;
				spriteEffects = GetComponent<SpriteEffects> ();

				currentPosition = transform.position;
				newPosition = currentPosition;

				canShoot = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		//Debug.Log (pickupDistance);
				transform.position = Vector3.Lerp (transform.position, newPosition, 0.25f);
				
				//Grabbing touch screen input
				HandleInput (SimpleGesture.instance.GetGesture ());

				if (SimpleGesture.instance.GetGesture ().InputState == InputState.SwipeUp) {
						Move (2);
				}
				if (SimpleGesture.instance.GetGesture ().InputState == InputState.SwipeDown) {
						Move (-2);
				}


				if (Input.GetKeyDown (KeyCode.W)) {
						Move (2);
				}
				if (Input.GetKeyDown (KeyCode.S)) {
						Move (-2);
				}

				if (Input.GetKeyDown (KeyCode.Space)) {
						Fire ();
				}

				MoveAlongX (Time.deltaTime);

		}

		void HandleInput (InputData input)
		{
				//left side input controls
				if (input.CurrentTouchPoint.x < screenMiddleWidth) {

						switch (input.InputState) {

						case InputState.SwipeUp:
								{
										Move (2);
										break;
								}
						case InputState.SwipeDown:
								{
										Move (-2);
										break;
								}
						default:
								{
										break;
								}
						}
				}
				//right side input controls
				if (input.CurrentTouchPoint.x > screenMiddleWidth) {
						switch (input.InputState) {
				
						case InputState.Tap:
								{
										Fire ();
										break;
								}			
						default:
								{
										break;
								}
						}
				}

		}

		void Move (float direction)
		{
				newY = transform.position.y + direction;
				if (newY > maxY) {
						newY = maxY;
				} else if (newY < minY) {
						newY = minY;
				}

				newPosition = new Vector3 (newPosition.x, newY, 0);
		}

		void MoveAlongX (float direction)
		{
				if (!hit) {
						newX = transform.position.x + (direction * 0.5f);
						if (newX > maxX) {
								newX = maxX;
						} else if (newX < minX) {
								newX = minX;
						}
						newPosition = new Vector3 (newX, newPosition.y, 0);
				}
		}

		void Fire ()
		{
				if (canShoot) {
						Debug.Log ("Pew");
						GameObject mineClone = Instantiate (mineBullet, new Vector3 (this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity) as GameObject;
						canShoot = false;
						StartCoroutine (CannotShoot ());
				}
		}

		IEnumerator CannotShoot ()
		{
				yield return new WaitForSeconds (timeBetweenShot);
				canShoot = true;
		}

		
		public void Collision ()
		{
				if (!hit) {
						spriteEffects.StartFlicker ();
						MoveAlongX (-1);
						SetHit (true);
						StartCoroutine (CannotBeHit ());
				}
		}



		public void SetHit (bool _hit)
		{
				hit = _hit;
		}
		

		IEnumerator CannotBeHit ()
		{
				GetComponent<Collider2D> ().enabled = false;
				yield return new WaitForSeconds (0.5f);
				GetComponent<Collider2D> ().enabled = true;
				SetHit (false);
		}

}
