using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public float speed = 2.8f;
    private float maxSpeed = 2.8f;
    private float minSpeed = 1.4f;
    private float speedDecreaseTimer = 0.1f;
    private float speedDecreaseIncrement = 0.3f;
    private float speedIncreaseTimer = 0.1f;
    private float speedIncreaseIncrement = 0.3f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        // Set default values for UI.
        healthText.UpdateHealth(paranoia);

        

    }
    public float yRot=0;
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

    public IEnumerator decreaseSpeed()
    {
        Debug.Log("decreaseSpeed() called.");
        while (speed > minSpeed)
        {
            speed -= speedDecreaseIncrement;
            if (speed < minSpeed)
            {
                speed = minSpeed;
            }
            yield return new WaitForSeconds(speedDecreaseTimer);
        }
        yield break;
    }

    public IEnumerator increaseSpeed()
    {
        Debug.Log("increaseSpeed() called.");
        while (speed < maxSpeed)
        {
            speed += speedIncreaseIncrement;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            yield return new WaitForSeconds(speedIncreaseTimer);
        }
        yield break;
    }
}
