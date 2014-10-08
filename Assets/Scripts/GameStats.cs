using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour
{

	public static GameStats instance;
	float pickupDistance = 1.5f;
	float currentSpeed = 6.0f;
	private float screenWidth;
	private float halfScreenWidth;	

	void Awake ()
	{
		if (instance != null)
			GameObject.Destroy (instance);
		else
			instance = this;
	
		DontDestroyOnLoad (instance);
	}

	public void SetValueInTime (string stat, float time, float value)
	{
		StartCoroutine (SetValueInTimeEnum (stat, time, value));
	}

	IEnumerator SetValueInTimeEnum (string stat, float time, float value)
	{
		yield return new WaitForSeconds (time);
		switch (stat) {
		case "PickupDistance":
		{
			SetPickupDistance (value);	
			break;
		}
		case "CurrentSpeed":
		{
			SetCurrentSpeed (value);
			break;
		}
		}
	}

	public void SetPickupDistance (float distance)
	{
		pickupDistance = distance;
	}

	public void ResetPickupDistance ()
	{
		pickupDistance = 1.5f;
	}

	public float GetPickupDistance ()
	{				
		return pickupDistance;
	}

	public void SetCurrentSpeed (float value)
	{
		currentSpeed = value;
	}

	public void ResetCurrentSpeed ()
	{
		currentSpeed = 4.0f;
	}

	public float GetCurrentSpeed ()
	{				
		return currentSpeed;
	}

	public float GetScreenWidth ()
	{
		if (screenWidth == 0) {
			screenWidth = Camera.main.orthographicSize * 2;
		}
		return screenWidth;
	}

	public void RecalculateScreenWidth()
	{	
		screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
	}

	public float GetHalfScreenWidth()
	{
		halfScreenWidth = GetScreenWidth() / 2;
	
		return halfScreenWidth;
	}
}
