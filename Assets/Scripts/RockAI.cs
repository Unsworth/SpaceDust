using UnityEngine;
using System.Collections;

public class RockAI : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		rigidbody2D.velocity = new Vector2 (GameStats.instance.GetCurrentSpeed () * -1, 0);
		if(transform.position.x < -10)
		{
			UIManager.instance.SetScore(10);
			Destroy(gameObject);
		}
	}
}
