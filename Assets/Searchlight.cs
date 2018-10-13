using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Searchlight : MonoBehaviour
{
    public player player;
    public Light light;
    public int damage;

    private IEnumerator increaseParanoiaCoroutine;
    private IEnumerator decreaseParanoiaCoroutine;

    public int redCounter = 0;
    private int redCounterMin = 0;
    private int redCounterMax = 10;
    private float changeColorTimer = 0.05f;
    private IEnumerator turnRedCoroutine;
    private IEnumerator turnWhiteCoroutine;

    private IEnumerator decreaseSpeedCoroutine;
    private IEnumerator increaseSpeedCoroutine;

    public FOVImage fovImage;
    private IEnumerator decreaseFOVCoroutine;
    private IEnumerator increaseFOVCoroutine;

    // Use this for initialization
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<player>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Remove existing coroutines, start increaseParanoiaCoroutine.
            if (decreaseParanoiaCoroutine != null)
            {
                player.StopCoroutine(decreaseParanoiaCoroutine);
                decreaseParanoiaCoroutine = null;
            }
            if (increaseParanoiaCoroutine == null)
            {
                increaseParanoiaCoroutine = player.increaseParanoia(damage);
                player.StartCoroutine(increaseParanoiaCoroutine);
            }
            if (turnWhiteCoroutine != null)
            {
                StopCoroutine(turnWhiteCoroutine);
                turnWhiteCoroutine = null;
            }
            if (turnRedCoroutine == null)
            {
                turnRedCoroutine = turnRed();
                StartCoroutine(turnRedCoroutine);
            }
            if (increaseSpeedCoroutine != null)
            {
                player.StopCoroutine(increaseSpeedCoroutine);
                increaseSpeedCoroutine = null;
            }
            if (decreaseSpeedCoroutine == null)
            {
                decreaseSpeedCoroutine = player.decreaseSpeed();
                player.StartCoroutine(decreaseSpeedCoroutine);
            }
            if (increaseFOVCoroutine != null)
            {
                fovImage.StopCoroutine(increaseFOVCoroutine);
                increaseFOVCoroutine = null;
            }
            if (decreaseFOVCoroutine == null)
            {
                decreaseFOVCoroutine = fovImage.decreaseFOV();
                fovImage.StartCoroutine(decreaseFOVCoroutine);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Remove existing coroutines, start increaseParanoiaCoroutine.
            if (increaseParanoiaCoroutine != null)
            {
                player.StopCoroutine(increaseParanoiaCoroutine);
                increaseParanoiaCoroutine = null;
            }
            if (decreaseParanoiaCoroutine == null)
            {
                decreaseParanoiaCoroutine = player.decreaseParanoia();
                player.StartCoroutine(decreaseParanoiaCoroutine);
            }
            if (turnRedCoroutine != null)
            {
                StopCoroutine(turnRedCoroutine);
                turnRedCoroutine = null;
            }
            if (turnWhiteCoroutine == null)
            {
                turnWhiteCoroutine = turnWhite();
                StartCoroutine(turnWhiteCoroutine);
            }
            if (decreaseSpeedCoroutine != null)
            {
                player.StopCoroutine(decreaseSpeedCoroutine);
                decreaseSpeedCoroutine = null;
            }
            if (increaseSpeedCoroutine == null)
            {
                increaseSpeedCoroutine = player.increaseSpeed();
                player.StartCoroutine(increaseSpeedCoroutine);
            }
            if (decreaseFOVCoroutine != null)
            {
                fovImage.StopCoroutine(decreaseFOVCoroutine);
                decreaseFOVCoroutine = null;
            }
            if (increaseFOVCoroutine == null)
            {
                increaseFOVCoroutine = fovImage.increaseFOV();
                fovImage.StartCoroutine(increaseFOVCoroutine);
            }
        }
    }

    private IEnumerator turnRed()
    {
        Debug.Log("turnRed() called.");
        while (redCounter < redCounterMax)
        {
            redCounter += 1;
            light.color = Color.Lerp(Color.white, Color.red, (float) redCounter / (float) redCounterMax);
            yield return new WaitForSeconds(changeColorTimer);
        }
        yield break;
    }

    private IEnumerator turnWhite()
    {
        Debug.Log("turnWhite() called.");
        while (redCounter > redCounterMin)
        {
            redCounter -= 1;
            light.color = Color.Lerp(Color.white, Color.red, (float) redCounter / (float) redCounterMax);
            yield return new WaitForSeconds(changeColorTimer);
        }
        yield break;
    }
}
