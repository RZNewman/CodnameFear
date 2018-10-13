using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour {

    public player playerComponent;
    public int damage;
    public Light light;

	// Use this for initialization
	void Start () {
        GameObject playerHealthObject = GameObject.FindWithTag("Player");
        if (playerHealthObject != null)
        {
            playerComponent = playerHealthObject.GetComponent<player>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay(): Called with collider " + other);
        if (other.gameObject.CompareTag("Player"))
        {
            int newHealth = other.gameObject.GetComponent<player>().detectedBySpotlight(damage);
            float percentage = newHealth / 100.0f;
            Debug.Log("OnTriggerStay(): newHealth " + newHealth + " percentage " + percentage);
            Color lerpedColor = Color.Lerp(Color.red, Color.white, percentage);
            Debug.Log("OnTriggerStay(): lerpedColor " + lerpedColor);
            light.color = lerpedColor;
        }
    }
}
