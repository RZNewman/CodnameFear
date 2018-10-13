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
        Cursor.lockState = CursorLockMode.Locked;
	}
    public float yRot=0;
    public const float speed = 2.8f;
	// Update is called once per frame
	void Update () {
        Vector3 h = Input.GetAxis("Horizontal") * transform.right;
        Vector3 v  = Input.GetAxis("Vertical") * transform.forward;
        Vector3 vel = (h + v).normalized * speed*Time.deltaTime;

        cc.Move(vel);
        //rb.velocity = vel;
        yRot+= Input.GetAxis("Mouse X");
        yRot = yRot % 360;
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
