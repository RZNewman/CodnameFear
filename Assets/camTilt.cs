using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTilt : MonoBehaviour {
    player p;
	// Use this for initialization
	void Start () {
        p = GetComponentInParent<player>();
	}
    float tilt=0;
    float tiltMin = -80;
    float tiltMax = 60;
	// Update is called once per frame
	void Update () {
        tilt -= Input.GetAxis("Mouse Y");
        if (tilt < tiltMin)
            tilt = tiltMin;
        if (tilt > tiltMax)
            tilt = tiltMax;
        transform.rotation = Quaternion.Euler(tilt,p.yRot, 0);
    }
}
