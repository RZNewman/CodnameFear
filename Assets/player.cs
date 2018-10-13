using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    Rigidbody rb;
    CharacterController cc;
    public HealthText healthText;

    public int paranoia = 0;
    private float paranoiaIncreaseTimer = 0.2f;
    private int paranoiaDecreaseIncrement = 1;
    private float paranoiaDecreaseTimer = 1.0f;
    private int paranoiaMin = 0;
    private int paranoiaMax = 100;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        // Set default values for UI.
        healthText.UpdateHealth(paranoia);
        
	}
    public float yRot=0;
    public const float speed = 2.8f;
	// Update is called once per frame
	void Update () {
        Vector3 h = Input.GetAxis("Horizontal") * transform.right;
        Vector3 v  = Input.GetAxis("Vertical") * transform.forward;
        Vector3 vel = (h + v).normalized * speed*Time.deltaTime;

        cc.Move(vel);
        //rb.velocity = vel;
        yRot+= Input.GetAxis("Mouse X");
        yRot = yRot % 360;
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    public int detectedBySpotlight(int damage)
    {
        // Function returns updated paranoia after we account for the damage.

        Debug.Log("detectedBySpotlight(): Called with damage " + damage);
        // Maybe later: don't calculate damage if we are already calculating it currently (i.e. if there are multiple overlapping spotlights).
        
        paranoia -= damage;
        if (paranoia < 0)
        {
            paranoia = 0;
        }
        healthText.UpdateHealth(paranoia);
        return paranoia;
    }

    public IEnumerator increaseParanoia(int paranoiaStep)
    {
        // While the player is in a spotlight, this coroutine continually increases the paranoia.
        // Uses values set from the spotlight.
        Debug.Log("increaseParanoia coroutine started with step " + paranoiaStep);
        while (true)
        {
            // Increases player's paranoia and update the UI.
            paranoia += paranoiaStep;
            healthText.UpdateHealth(paranoia);
            // If reach the maximum, TODO: Cause death! :o
            if (paranoia > paranoiaMax)
            {
                paranoia = paranoiaMax;
                yield break;
            }

            yield return new WaitForSeconds(paranoiaIncreaseTimer);
        }
    }

    public IEnumerator decreaseParanoia()
    {
        // While the player is not in a spotlight, this coroutine continually decreases the paranoia until min level.
        // Uses values set by the Player class.
        Debug.Log("decreaseParanoia coroutine started.");
        while (true)
        {
            // Decreases player's paranoia and update the UI.
            paranoia -= paranoiaDecreaseIncrement;
            healthText.UpdateHealth(paranoia);
            // If reach the minimum, we can stop the coroutine.
            if (paranoia <= paranoiaMin)
            {
                paranoia = paranoiaMin;
                yield break;
            }

            yield return new WaitForSeconds(paranoiaDecreaseTimer);
        }
    }
}
