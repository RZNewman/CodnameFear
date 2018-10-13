using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {
    
    public Text paranoiaText;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void UpdateHealth(int paranoia)
    {
        Debug.Log("UpdateHealth(): Called with paranoia " + paranoia);
        paranoiaText.text = "Paranoia: " + paranoia;
    }
}
