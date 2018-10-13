using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRotate : MonoBehaviour {
    bool triggered = false;
    float rotation = 0;
    float start;
	// Use this for initialization
	void Start () {
        start = transform.rotation.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered & rotation < 180)
        {
            rotation += 1;
            transform.rotation = Quaternion.Euler(0, start + rotation, 0);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            triggered = true;
        }
    }
}
