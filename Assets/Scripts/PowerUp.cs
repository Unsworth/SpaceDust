using UnityEngine;
using System.Collections;

public class PowerUp : Collectable {

	// Use this for initialization
	void Start () {
		base.Start();
		rigidbody2D.velocity = new Vector2 (-4, 0);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			//Destroy(gameObject);
		}
	}

	protected override void PickedUp()
	{
		UIManager.instance.SetScore (25);
		Debug.Log ("Yes");
		GameStats.instance.SetPickupDistance (7.5f);
		GameStats.instance.SetValueInTime ("PickupDistance", 20.0f, 1.5f);
		base.PickedUp ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

	
	}
}
