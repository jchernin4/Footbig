using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float maxHealth = 100f;
	public float curHealth = 100f;
	void Start() {

	}

	void Update() {
		if (curHealth <= 0) {
			Destroy(this.gameObject);
		}
	}

	/*void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Glock") {
			curHealth -= other.gameObject.GetComponent<GlockBullet>().damage;
			Destroy(other.gameObject);

		} else if (other.gameObject.tag == "Shotgun") {
			curHealth -= other.gameObject.GetComponent<ShotgunBullet>().damage;
			Destroy(other.gameObject);
		}
	}*/
}