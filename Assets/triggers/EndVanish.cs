using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndVanish : MonoBehaviour {
    GameObject[] all;
    public GameObject door;
    bool trigger1 = false;

    GameObject player;
    // Use this for initialization
    void Start()
    {
        all = GameObject.FindGameObjectsWithTag("all");
    }


    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!trigger1)
        {
            //Debug.Log("trigger1");
            player = other.gameObject;
            foreach (GameObject manq in all)
            {
                Destroy(manq);
                
            }
            //door.transform.localPosition = new Vector3(2, 0, -2);
            //door.transform.localRotation = Quaternion.LookRotation(Vector3.left);
            trigger1 = true;
        }
    }
}
