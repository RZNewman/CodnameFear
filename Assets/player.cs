using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    Rigidbody rb;
    CharacterController cc;
    public HealthText healthText;

    public int paranoia = 100;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        // Set default values for UI.
        healthText.UpdateHealth(paranoia);
        
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

    public int detectedBySpotlight(int damage)
    {
        // Function returns updated paranoia after we account for the damage.

        Debug.Log("detectedBySpotlight(): Called with damage " + damage);
        // Maybe later: don't calculate damage if we are already calculating it currently (i.e. if there are multiple overlapping spotlights).
        
        paranoia -= damage;
        if (paranoia < 0)
        {
            paranoia = 0;
        }
        healthText.UpdateHealth(paranoia);
        return paranoia;
    }
}
