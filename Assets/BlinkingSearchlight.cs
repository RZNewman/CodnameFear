using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingSearchlight : MonoBehaviour {

    public float timeActive = 2.0f;
    public float timeInactive = 2.0f;
    public float fadeTime = 1.0f;
    public float intensityMax = 15;
    public float intensityMin = 0;

    public Light light;
    public CapsuleCollider collider;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartBlinking());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator StartBlinking()
    {
        while (true)
        {
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(timeActive);
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(timeInactive);
        }
    }

    private IEnumerator FadeIn()
    {
        // Ten steps for the fade.
        for (int i = 1; i <= 10; i++)
        {
            light.intensity = ((float)i * intensityMax) / 10.0f;
            // Turn on the collider halfway through.
            if (i >= 5)
            {
                collider.enabled = true;
            }
            yield return new WaitForSeconds(fadeTime / 10.0f);
        }
        yield break;
    }

    private IEnumerator FadeOut()
    {
        // Ten steps for the fade.
        for (int i = 9; i >= 0; i--)
        {
            light.intensity = ((float)i * intensityMax) / 10.0f;
            // Turn off the collider halfway through.
            if (i <= 5)
            {
                collider.enabled = false;
            }
            yield return new WaitForSeconds(fadeTime / 10.0f);
        }
        yield break;
    }
}
