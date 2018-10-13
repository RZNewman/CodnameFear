using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingSearchlight : MonoBehaviour
{

    public float timeActive = 2.0f;
    public float timeInactive = 2.0f;
    public float fadeTime = 1.0f;
    public float intensityMax = 15;
    public float intensityMin = 0;
    public int intensityCounter = 0;
    public bool fadeInBool = true; // whether we are currently fading in or out

    public Light light;
    public CapsuleCollider collider;
    public bool isPaused = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartBlinking());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator StartBlinking()
    {
        if (fadeInBool)
        {
            StartCoroutine(FadeIn(intensityCounter));
        } else
        {
            StartCoroutine(FadeOut(intensityCounter));
        }
        yield return null;
    }

    private IEnumerator FadeIn(int start)
    {
        Debug.Log("BlinkingSearchlight FadeIn() intensityCounter " + intensityCounter);
        fadeInBool = true;
        // Ten steps for the fade.
        for (int i = start; i <= 10; i++)
        {
            intensityCounter = i;
            light.intensity = ((float)intensityCounter * intensityMax) / 10.0f;
            // Turn on the collider halfway through.
            if (intensityCounter >= 5)
            {
                collider.enabled = true;
            }
            yield return new WaitForSeconds(fadeTime / 10.0f);
        }
        yield return new WaitForSeconds(timeActive);
        StartCoroutine(FadeOut(intensityCounter));
    }

    private IEnumerator FadeOut(int start)
    {
        Debug.Log("BlinkingSearchlight FadeOut() intensityCounter " + intensityCounter);
        fadeInBool = false;
        // Ten steps for the fade.
        for (int i = start; i >= 0; i--)
        {
            intensityCounter = i;
            light.intensity = ((float)intensityCounter * intensityMax) / 10.0f;
            // Turn off the collider halfway through.
            if (intensityCounter <= 5)
            {
                collider.enabled = false;
            }
            yield return new WaitForSeconds(fadeTime / 10.0f);
        }
        yield return new WaitForSeconds(timeInactive);
        StartCoroutine(FadeIn(intensityCounter));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //isPaused = false;
            StartCoroutine(StartBlinking());
        }
    }
}
