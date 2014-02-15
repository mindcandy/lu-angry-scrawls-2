using UnityEngine;
using System.Collections;

public class ScoreGraphic : MonoBehaviour {

	public float startScale = 0.4f;
	public float endScale = 1.0f;
	public float speedY = 10.0f;
	public float duration = 1.0f;

	float time;

	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;

		float t = Mathf.Clamp01(time / duration);
		float scale = Mathf.Lerp(startScale, endScale, t);
		float alpha = 1.0f - t;

		transform.localScale = new Vector3(scale, scale, 1.0f);
		transform.position = transform.position + new Vector3(0.0f, speedY * Time.deltaTime, 0.0f);
		renderer.material.color = new Color(1.0f, 1.0f, 1.0f, alpha);

		if (time > duration) {
			Destroy(this.gameObject);
		}
	}
}
