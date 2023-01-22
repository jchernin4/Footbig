using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {
	public float maxHealth = 100f;
	public float curHealth = 100f;

	public float maxStamina = 100f;
	public float curStamina = 100f;

	public Slider healthSlider, staminaSlider;

	public SpriteMask healthMask;
	public float lastUpdatedHealth = 100f;
	void Start() {
		healthSlider.maxValue = maxHealth;
		healthSlider.value = curHealth;

		staminaSlider.maxValue = maxStamina;
		staminaSlider.value = curStamina;
	}

	void Update() {
		if (Input.GetKeyDown("h")) {
			curHealth -= 10f;
		}

		healthSlider.value = curHealth;
		staminaSlider.value = curStamina;

		if (lastUpdatedHealth != curHealth) {
			moveMask();
		}
	}

	void moveMask() {
		// Full health = mask at x = 195.5
		// No health = mask at x = 0

		// health / 100 = x / 195.5
		// X coordinate is 1.955 * health val
		Vector3 pos = healthMask.transform.position;
		if (pos.x != curHealth * 1.955) {
			if (lastUpdatedHealth < curHealth) {
				pos.x--;
				healthMask.transform.position = pos;

			} else if (lastUpdatedHealth > curHealth) {
				pos.x--;
				healthMask.transform.position = pos;
			}

		} else {
			lastUpdatedHealth = curHealth;
		}
	}
}