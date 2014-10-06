using UnityEngine;
using System.Collections;

public enum InputState{
	NoTouch,
	TouchDown,
	SwipeUp,
	SwipeDown,
	SwipeLeft,
	SwipeRight,
	Tap,
}

public struct InputData{
	InputState inputState;
	Vector2 currentTouchPoint;

	public InputState InputState {
		get {
			return inputState;
		}
		set {
			inputState = value;
		}
	}

	public Vector2 CurrentTouchPoint {
		get {
			return currentTouchPoint;
		}
		set {
			currentTouchPoint = value;
		}
	}
}


public class SimpleGesture : MonoBehaviour {

	public static SimpleGesture instance;

	private Vector2 touchStart;
	private Vector2 touchEnd;
	private Vector2 touchMoved;
	private Vector2 touchStartWorld;
	private Vector2 touchEndWorld;
	private Vector2 touchMovedWorld;
	private float swipeDistance;
	private float minSwipeDistance = 10.0f;
	private InputData currentInput;
	private InputData tempInput;

	void Awake()
	{
		if(instance != null)
			GameObject.Destroy(instance);
		else
			instance = this;
		
		DontDestroyOnLoad(instance);
		}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tempInput = GetGesture();
	}


	public InputData GetGesture(){
		if (Input.touchCount > 0)
		{
			switch(Input.GetTouch(0).phase)
			{
			case TouchPhase.Began:
				touchStart = Input.GetTouch(0).position;
				touchStartWorld = Camera.main.ScreenToWorldPoint(touchStart);
				touchEnd = touchStart;
				touchEndWorld = touchStartWorld;
				currentInput.CurrentTouchPoint = touchStart;
				currentInput.InputState = InputState.TouchDown;
				return currentInput;
			case TouchPhase.Ended:
				touchEnd = Input.GetTouch(0).position;
				swipeDistance = (touchStart - touchEnd).magnitude;

				if(swipeDistance > minSwipeDistance)
				{
					if(Mathf.Sign(touchEnd.y - touchStart.y) > 0)
					{
						currentInput.CurrentTouchPoint = touchEnd;
						currentInput.InputState = InputState.SwipeUp;
						Debug.Log ("Swipe Up");
					}else{
						currentInput.CurrentTouchPoint = touchEnd;
						currentInput.InputState = InputState.SwipeDown;
						Debug.Log ("Swipe Down");
					}
				}else{
					currentInput.CurrentTouchPoint = touchEnd;
					currentInput.InputState = InputState.Tap;
					Debug.Log ("Tap");
				}
				return currentInput;
			}
		}else{
			currentInput.CurrentTouchPoint = Vector2.zero;
			currentInput.InputState = InputState.NoTouch;
			return currentInput;
		}
		currentInput.CurrentTouchPoint = Vector2.zero;
		currentInput.InputState = InputState.NoTouch;
		return currentInput;
	}

}
