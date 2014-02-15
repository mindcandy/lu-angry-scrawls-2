using UnityEngine;
using System.Collections;

//
// allows an object to take damage and be destroyable - is damaged by physical contact
//
public class Destroyable : MonoBehaviour {

	// how strong is this object? larger values mean it will be harder to break
	public float toughness = 10.0f;

	// ignore force less than this
	const float threshold = 0.1f;

	// health of object
	float health;

	// Use this for initialization
	void Start () {
		health = toughness;
	}

	// when a collision occurs
	void OnCollisionEnter2D (Collision2D collision) {

		if (rigidbody2D != null) {

			// calculate force of collision
			float force = collision.relativeVelocity.magnitude * (massOf(rigidbody2D) + massOf(collision.rigidbody));

			if (force > threshold) {
				health -= force;

				if (health < 0.0f) {
					// send message saying this is destroyed
					SendMessage("OnDestroyed", SendMessageOptions.DontRequireReceiver);
					Destroy(this.gameObject);
				} else {
					// send a message saying how damaged this object is (1= no damage, 0= dead)
					SendMessage("OnDamaged", health/toughness, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	// get the mass of the body or 0 if there is no body
	float massOf(Rigidbody2D body) {
		if (body == null) 
			return 0;
		else
			return body.mass;
	}
}
