using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHand : MonoBehaviour {
	//public GameObject flashlight;
	public GameObject glock, shotgun;

	void Start() {
		//flashlight.SetActive(true);
		glock.SetActive(true);
		shotgun.SetActive(false);
	}
	void Update() {
		// TODO: this is retarded YO same!!
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			//flashlight.SetActive(true);
			glock.SetActive(true);
			shotgun.SetActive(false);
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			//flashlight.SetActive(false);
			glock.SetActive(false);
			shotgun.SetActive(true);

		}
	}
}
