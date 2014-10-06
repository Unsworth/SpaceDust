using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dust : MonoBehaviour {

	public List<Sprite> sprites;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = sprites [Random.Range (0, sprites.Count)];
		GetComponent<SpriteRenderer> ().color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
		float randomScale = Random.Range (1.0f, 3.0f);
		transform.localScale = new Vector2 (randomScale, randomScale);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
