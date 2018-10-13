using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPoint : MonoBehaviour {

    GameObject[] all;
    GameObject baliff;
    public GameObject movePos;
    public GameObject door;
    public GameObject point;
    bool trigger1 = false;
    bool trigger2 = false;
    float timer = 0;
    float strikes = 3;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        all = GameObject.FindGameObjectsWithTag("all");
        baliff = GameObject.FindGameObjectWithTag("bailiff");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //Gavel Sound
                strikes--;
                if (strikes > 0)
                {
                    timer = 1;
                }
                Debug.Log("Gavel");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!trigger1)
        {
            //Debug.Log("trigger1");
            player = other.gameObject;
            foreach (GameObject manq in all)
            {
                Vector3 diff = point.transform.position - manq.transform.position;
                diff.y = 0;
                manq.transform.rotation = Quaternion.LookRotation(diff);
            }
            baliff.transform.position = movePos.transform.position;
            baliff.transform.rotation = movePos.transform.rotation;
            movePos.GetComponent<Collider>().enabled = true;
            door.transform.localPosition = new Vector3(2, 0, -2);
            door.transform.localRotation = Quaternion.LookRotation(Vector3.left);
            trigger1 = true;
            timer = 1;
        }
    }
}
