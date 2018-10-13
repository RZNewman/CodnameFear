using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {
    
    public Text healthText;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void UpdateHealth(int health)
    {
        Debug.Log("UpdateHealth(): Called with health " + health);
        healthText.text = "Health: " + health;
    }
}
