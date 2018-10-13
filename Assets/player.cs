using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    Rigidbody rb;
    CharacterController cc;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
	}
    const float speed = 2.5f;
	// Update is called once per frame
	void Update () {
        Vector3 h = Input.GetAxis("Horizontal") * Vector3.right;
        Vector3 v  = Input.GetAxis("Vertical") * Vector3.forward;
        Vector3 vel = (h + v).normalized * speed*Time.deltaTime;
        cc.Move(vel);
    }
}
