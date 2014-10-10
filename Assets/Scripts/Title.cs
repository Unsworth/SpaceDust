using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	SpriteRenderer renderer;
	float alphaValue = 0.0f;
	float startTime;
	public GameObject prototypeLabel;

	// Use this for initialization
	void Start () {
	
		renderer = GetComponent<SpriteRenderer> ();
		startTime = Time.time;

	}

	void Update () {
		FadeIn ();
		Stamp ();
	}

	void FadeIn()
	{
		if (alphaValue < 1) {
						renderer.color = new Color (1, 1, 1, alphaValue);
						alphaValue += Time.deltaTime;
				}
		}

	void Stamp()
	{
				if (Time.time > startTime + 2.0f) {
						prototypeLabel.transform.position = Vector3.Lerp (prototypeLabel.transform.position, new Vector3 (prototypeLabel.transform.position.x, prototypeLabel.transform.position.y, -0.1f), 0.2f);
						prototypeLabel.transform.localScale = Vector3.Lerp (prototypeLabel.transform.localScale, new Vector3 (3, 3, 1), 0.2f);

						if (SimpleGesture.instance.GetGesture ().InputState == InputState.Tap || Input.GetKeyDown (KeyCode.Space)) {			
								{
										Application.LoadLevel ("DanielTestBed");
								}
						}
				}
		}
}
