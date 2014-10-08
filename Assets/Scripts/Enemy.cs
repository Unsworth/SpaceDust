using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speedModifier = 1;
	public int scoreModifier;
	float currentSpeed;
	// Use this for initialization
	void Start () {
		currentSpeed = GameStats.instance.GetCurrentSpeed ();
		rigidbody2D.velocity = new Vector2 (GameStats.instance.GetCurrentSpeed () * -speedModifier, 0);
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if (currentSpeed != GameStats.instance.GetCurrentSpeed ()) {
						rigidbody2D.velocity = new Vector2 (GameStats.instance.GetCurrentSpeed () * -speedModifier, 0);
						currentSpeed = GameStats.instance.GetCurrentSpeed ();
				}
		if(transform.position.x < -10)
		{
			UIManager.instance.SetScore(scoreModifier);
			Destroy(gameObject);
		}
	}
}