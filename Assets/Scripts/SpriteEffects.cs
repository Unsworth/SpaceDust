using UnityEngine;
using System.Collections;

public class SpriteEffects : MonoBehaviour {

	bool flickering = false;
	float flickerTime = 0.5f;
	float fadeValue = 1.0f;
	Color currentColor;
	SpriteRenderer thisSprite;
	
	void Awake()
	{
		thisSprite = GetComponent<SpriteRenderer>();
	}
		
	void Update ()
	{
//		if (mFadingOut)
//		{
//			mCurrentFadeOutTime += Time.deltaTime;
//			fadeValue = Mathf.PingPong(Time.time, 0.05f) / 0.05f;  
//			thisSprite.color = new Color (1.0f, 1.0f, 1.0f, fadeValue);
//			if (mCurrentFadeOutTime >= mFadeOutTime)
//			{
//				//Fading Out finished:
//				mFadingOut = false;
//				mCurrentFadeOutTime = 0.0f;
//				this.GetComponent<SpriteRenderer>().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
//			}
//		}
		Flicker ();
	}

	void Flicker()
	{
		if (flickering) {
						fadeValue = Mathf.PingPong (Time.time, 0.05f) / 0.05f;  
						thisSprite.color = new Color (1.0f, 1.0f, 1.0f, fadeValue);
				}
	}

	public void StartFlicker()
	{
		StartCoroutine (FlickerEffect ());
		}

	IEnumerator FlickerEffect ()
	{
		if (flickering == false) {
						flickering = true;
			yield return new WaitForSeconds (flickerTime);
						flickering = false;
						thisSprite.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				}
	}
}

