using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuryMove : MonoBehaviour {

    GameObject[] theJury;
    GameObject baliff;
    public Vector3 offset;
    public GameObject movePos;
    public GameObject door;
    bool trigger1 = false;
    bool trigger2 = false;
    bool completed = false;
    float timer = 0;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        theJury = GameObject.FindGameObjectsWithTag("jury");
        baliff = GameObject.FindGameObjectWithTag("bailiff");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //Gavel Sound
                completed = true;
                Debug.Log("Gavel");
            }
        }
        if (completed)
        {
            float yRot = player.transform.rotation.eulerAngles.y%360;
            //Debug.Log(yRot);
            if (yRot > 210)
            {
                trigger2 = true;
                completed = false;
                //Debug.Log("trigger2");
                foreach (GameObject manq in theJury)
                {
                    Vector3 diff = player.transform.position - manq.transform.position;
                    diff.y = 0;
                    manq.transform.rotation = Quaternion.LookRotation(diff);
                }
                baliff.transform.position = movePos.transform.position;
                baliff.transform.rotation = movePos.transform.rotation;
                movePos.GetComponent<Collider>().enabled = true;
                door.transform.localPosition = new Vector3(2, 0, -2);
                door.transform.localRotation = Quaternion.LookRotation(Vector3.left);

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!trigger1)
        {
            //Debug.Log("trigger1");
            player = other.gameObject;

            trigger1 = true;
            timer = 3;
        }
    }
}
