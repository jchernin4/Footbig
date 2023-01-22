using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FootbigController : MonoBehaviour {
	public float lookRadius = 10f;

	public GameObject target;
	public NavMeshAgent agent;
	void Start() {
		agent = GetComponent<NavMeshAgent>();
	}
	void Update() {
		agent.SetDestination(target.transform.position);

		/*float distance = Vector3.Distance(target.position, transform.position);
		
		if (distance <= lookRadius) {
			agent.SetDestination(target.position);
		}*/
	}

	/*void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}*/
}
