using UnityEngine;
using System.Collections;

public class ReloadUI : MonoBehaviour {

	private float totalTime;
	private float animationDelay;
	private bool animate;
	private float maxAlpha = 1.0f;
	// Use this for initialization
	void Start () {
		animate = false;
		renderer.material.SetFloat ("_Cutoff", 1.0f);
		gameObject.transform.localScale = new Vector3 (GameStats.instance.GetScreenWidth () * 0.1f, 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time < totalTime && animate) {
			float currentTime = totalTime - Time.time;
			renderer.material.SetFloat ("_Cutoff", currentTime / animationDelay); 
			maxAlpha = currentTime / animationDelay;
		} else {
			animate = false;
			renderer.material.SetFloat ("_Cutoff", 1.0f); 
			maxAlpha = 1.0f;
		}
	}

	public void StartAnimation(float animationLength)
	{
		animationDelay = animationLength;
		totalTime = Time.time + animationDelay;
		animate = true;
	}
}
