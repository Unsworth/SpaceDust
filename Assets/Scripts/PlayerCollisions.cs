using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
	
	public LayerMask whatHurts;
	
	void Update ()
	{
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{			
		if (other.gameObject.tag == "HardRock") {
			PlayerController.player.Collision();
			UIManager.instance.SetScore(-25);
			Debug.Log ("Hit");
		}

		if (other.gameObject.tag == "Enemy") {
			PlayerController.player.Collision();
			UIManager.instance.SetScore(-25);
			Debug.Log ("Hit");
		}

		if (other.gameObject.tag == "EnemyBullet") {
			PlayerController.player.Collision();
			UIManager.instance.SetScore(-25);
			Debug.Log ("Hit");
		}

		if (other.gameObject.tag == "BreakableRock") {
			PlayerController.player.Collision();
			UIManager.instance.SetScore(-25);
			Debug.Log ("Hit");
		}
	}
}
