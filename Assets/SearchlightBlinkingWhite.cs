using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchlightBlinkingWhite : MonoBehaviour {

    public CapsuleCollider collider;
    public SpriteRenderer spriteRenderer;
    public float timeActive = 3.0f;
    public float timeInactive = 3.0f;
    public float fadeTime = 1.0f;
    public float intensityMax = 15;
    public float intensityMin = 0;
    public int intensityCounter = 0;
    public float fadeDelay = 0.0f;
    public bool fadeInBool = true; // whether we are currently fading in or out

    private IEnumerator fadeInCoroutine;
    private IEnumerator fadeOutCoroutine;

    // Use this for initialization
    void Start () {

        StartCoroutine(StartBlinking());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator StartBlinking()
    {
        yield return new WaitForSeconds(fadeDelay);
        if (fadeInBool)
        {
            StartCoroutine(FadeIn(intensityCounter));
        }
        else
        {
            StartCoroutine(FadeOut(intensityCounter));
        }
        yield return null;
    }

    private IEnumerator FadeIn(int start)
    {
        Debug.Log("BlinkingSearchlight FadeIn() intensityCounter " + intensityCounter);
        fadeInBool = true;
        for (int i = start; i <= intensityMax; i++)
        {
            intensityCounter = i;
            float intensity = (float)intensityCounter / (float)intensityMax;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, intensity);
            // Turn on the collider halfway through.
            if (intensityCounter >= intensityMax / 2.0f)
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
        for (int i = start; i >= 0; i--)
        {
            intensityCounter = i;
            Debug.Log("FadeOut intensityCounter " + intensityCounter);
            float intensity = (float)intensityCounter / (float) intensityMax;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, intensity);
            // Turn off the collider halfway through.
            if (intensityCounter <= intensityMax / 2.0f)
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
            StartCoroutine(StartBlinking());
        }
    }
}
