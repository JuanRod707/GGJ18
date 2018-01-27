using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class keyboardInput : MonoBehaviour {

    private NavMeshAgent meshAgent;
    public float MoveSpeed;

	void Start () {
        if (meshAgent == null)
            meshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) {
            meshAgent.Move(Vector3.left * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S)) {
            meshAgent.Move(Vector3.back * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.D)) {
            meshAgent.Move(Vector3.right * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.W)) {
            meshAgent.Move(Vector3.forward * MoveSpeed);
        }
    }
}
