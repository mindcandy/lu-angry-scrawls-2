using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject scoreGraphic;

	void OnDestroyed ()
	{
		if (scoreGraphic) {
			Instantiate(scoreGraphic, transform.position, Quaternion.identity);
		}
		Debug.Log("Enemy destroyed, +1000!!");
	}
}
