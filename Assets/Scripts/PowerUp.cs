using UnityEngine;
using System.Collections;

public class PowerUp : Collectable {

	// Use this for initialization
	void Start () {
		base.Start();

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
		GameStats.instance.SetCurrentSpeed (12);
		GameStats.instance.SetValueInTime ("CurrentSpeed", 10, 6);
		//GameStats.instance.SetPickupDistance (7.5f);
		//GameStats.instance.SetValueInTime ("PickupDistance", 20.0f, 1.5f);
		base.PickedUp ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

	
	}
}
