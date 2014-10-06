using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public static UIManager instance;
	protected float currentScore = 0;
	protected float highScore;

	protected Rect scoreArea = new Rect(0,0,Screen.width/5, Screen.height/10);


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

	}


	void OnGUI(){
		AutoResize(1024, 600);
		GUI.Label(scoreArea, "Score: " + currentScore.ToString());
	}

	public void SetScore(int points)
	{
		currentScore += points;
		if (currentScore < 0)
						currentScore = 0;
	}

	public static void AutoResize(int screenWidth, int screenHeight)
	{
		Vector2 resizeRatio = new Vector2((float)Screen.width/ screenWidth, (float)Screen.height/screenHeight);
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
	}
}
