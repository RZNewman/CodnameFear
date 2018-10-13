using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class publicStand : MonoBehaviour {
    GameObject[] thePublic;
    public Vector3 offset;
    bool triggered = false;
    public Mesh stand;
	// Use this for initialization
	void Start () {
        thePublic = GameObject.FindGameObjectsWithTag("public");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            foreach (GameObject manq in thePublic)
            {
                manq.transform.position += offset;
                manq.GetComponent<MeshFilter>().mesh = stand;
            }
            triggered = true;
        }
    }
        
}
