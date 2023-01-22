using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using TMPro;

public class UseHand : MonoBehaviour {
	//public GameObject flashlight;
	public GameObject glock, shotgun;
	public GameObject flashlightSource;
	public GameObject muzzleFlash;
	public ParticleSystem bulletParticle;

	public GameObject glockExit, shotgunExit;
	public GameObject glockBulletOrig, shotgunBulletOrig;

	public TextMeshProUGUI ammoText;
	// public TextMeshPro ammoText;

	public float glockForce = 80000f;
	public float glockDamage = 8f;
	public float glockCounter = 0f;
	public float glockDelayTime = 0.03f;

	public float glockLoaded = 18f;
	public float glockMagSize = 18f;
	public float glockAmmoReserve = 36f;

	public float shotgunForce = 70000f;
	public float shotgunDamage = 3f;
	public float shotgunCounter = 0f;
	public float shotgunDelayTime = 0.7f;

	public float shotgunLoaded = 6f;
	public float shotgunMagSize = 6f;
	public float shotgunAmmoReserve = 24f;
	void Start() {
		flashlightSource.SetActive(false);
	}

	void Update() {
		// TODO: This is also retarded YO SAME!

		/*if (!flashlight.activeSelf) {
			flashlightSource.SetActive(false);
		} */


		/*if (flashlight.activeSelf) {
			if (Input.GetKeyDown("f")) {
				flashlightSource.SetActive(!flashlightSource.activeSelf);
			}

		} */

		if (Input.GetKeyDown("f")) {
			flashlightSource.SetActive(!flashlightSource.activeSelf);
		}

		if (glock.activeSelf) {
			ammoText.text = glockLoaded + "/" + glockAmmoReserve;
			//flashlightSource.SetActive(false);

			if (Input.GetKeyDown("r") && glockLoaded < glockMagSize && glockAmmoReserve > 0) {
				float ammoToLoad = glockMagSize - glockLoaded; // Get amount of ammo to fill

				if (glockAmmoReserve >= ammoToLoad) {
					glockLoaded += ammoToLoad;
					glockAmmoReserve -= ammoToLoad;
				} else {
					glockLoaded += glockAmmoReserve; // If there isn't enough ammo for a full mag, add the rest of the reserve
					glockAmmoReserve = 0;
				}
			}

			if (Input.GetMouseButtonDown(0) && glockCounter > glockDelayTime) {
				if (glockLoaded > 0) {
					glockCounter = 0f;

					RaycastHit hit;
					Ray ray = new Ray(transform.position, transform.forward);
					bool hitObject = Physics.Raycast(ray, out hit, 100f);

					GameObject instantiated = Instantiate(glockBulletOrig, glockExit.transform.position, glockExit.transform.rotation) as GameObject;
					Rigidbody instantiatedRigidbody = instantiated.GetComponent<Rigidbody>();

					if (hitObject) {
						Vector3 direction = (hit.point - glockExit.transform.position).normalized;
						Quaternion lookRotation = Quaternion.LookRotation(direction);

						instantiated.transform.rotation = Quaternion.Slerp(glockExit.transform.rotation, lookRotation, 1);
					}

					instantiatedRigidbody.AddForce(instantiated.transform.forward * glockForce);
					if (hitObject) {
						GameObject hitObj = hit.transform.gameObject;
						if (hitObj.tag == "Footbig") {
							hitObj.GetComponent<Health>().curHealth -= glockDamage;
						}
					}

					Destroy(Instantiate(muzzleFlash, glockExit.transform.position, glockExit.transform.rotation), 0.06f);
					Destroy(instantiated, 1f);
					Destroy(Instantiate(bulletParticle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)), 1f);

					glock.GetComponent<Animation>().Play("GlockShoot");

					glockLoaded--;
				} else {
					// No ammo loaded
				}
			}
			glockCounter += Time.deltaTime;

		} else if (shotgun.activeSelf) {
			ammoText.text = shotgunLoaded + "/" + shotgunAmmoReserve;
			//flashlightSource.SetActive(false);

			if (Input.GetKeyDown("r") && shotgunLoaded < shotgunMagSize && shotgunAmmoReserve > 0) {
				float ammoToLoad = shotgunMagSize - shotgunLoaded; // Get amount of ammo to fill

				if (shotgunAmmoReserve >= ammoToLoad) {
					shotgunLoaded += ammoToLoad;
					shotgunAmmoReserve -= ammoToLoad;
				} else {
					shotgunLoaded += shotgunAmmoReserve; // If there isn't enough ammo for a full mag, add the rest of the reserve
					shotgunAmmoReserve = 0;
				}
			}

			if (Input.GetMouseButtonDown(0) && shotgunCounter > shotgunDelayTime) {
				if (shotgunLoaded > 0) {
					shotgunCounter = 0f;
					System.Random random = new System.Random();

					for (int i = 0; i < 7; i++) {
						/* Calc distance from bullet to shotgun exit, then draw ray from that distance but from the crosshair
						 */
						GameObject instantiated = Instantiate(shotgunBulletOrig, shotgunExit.transform.position, shotgunExit.transform.rotation) as GameObject;
						Rigidbody instantiatedRigidbody = instantiated.GetComponent<Rigidbody>();

						float randX = random.Next(-2, 2);
						float randY = random.Next(-2, 2);
						instantiated.transform.Rotate(Vector3.left); // Rotation correction
						instantiated.transform.Rotate(randX, randY, 0f, Space.Self); // Rotate by random amount

						RaycastHit hit;
						Ray ray = new Ray(transform.position, instantiated.transform.forward);
						bool hitObject = Physics.Raycast(ray, out hit, 100f);

						if (hitObject) {
							Vector3 direction = (hit.point - instantiated.transform.position).normalized;
							Quaternion lookRotation = Quaternion.LookRotation(direction);

							instantiated.transform.rotation = lookRotation;
						}


						instantiatedRigidbody.AddForce(instantiated.transform.forward * shotgunForce);
						if (hitObject) {
							GameObject hitObj = hit.transform.gameObject;
							if (hitObj.tag == "Footbig") {
								hitObj.GetComponent<Health>().curHealth -= shotgunDamage;
							}
						}
						Destroy(Instantiate(bulletParticle, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)), 1f);
					}
					Destroy(Instantiate(muzzleFlash, shotgunExit.transform.position, shotgunExit.transform.rotation), 0.06f);
					shotgunLoaded--;
				} else {
					// No ammo loaded
				}
			}
			shotgunCounter += Time.deltaTime;
		}
	}
}