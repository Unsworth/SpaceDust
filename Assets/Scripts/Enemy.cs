using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speedModifier;
	public int scoreModifier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
		rigidbody2D.velocity = new Vector2 (GameStats.instance.GetCurrentSpeed () * -speedModifier, 0);
		if(transform.position.x < -10)
		{
			UIManager.instance.SetScore(scoreModifier);
			Destroy(gameObject);
		}
	}
}