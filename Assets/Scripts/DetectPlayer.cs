using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay(): Called with collider " + other);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<player>().detectedBySpotlight(damage);
        }
    }
}
