using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVImage : MonoBehaviour {

    public Image image;
    private float alphaMin = 0.0f;
    private float alphaMax = 1.0f;
    private float changeAlphaStep = 0.1f;
    private float changeAlphaTimer = 0.05f;

	// Use this for initialization
	void Start () {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator decreaseFOV()
    {
        Debug.Log("decreaseFOV() called.");
        while (image.color.a < alphaMax)
        {
            float newAlpha = image.color.a + changeAlphaStep;
            if (newAlpha > alphaMax)
            {
                newAlpha = alphaMax;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            yield return new WaitForSeconds(changeAlphaTimer);
        }
        yield break;
    }

    public IEnumerator increaseFOV()
    {
        Debug.Log("increaseFOV() called.");
        while (image.color.a > alphaMin)
        {
            float newAlpha = image.color.a - changeAlphaStep;
            if (newAlpha < alphaMin)
            {
                newAlpha = alphaMin;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            yield return new WaitForSeconds(changeAlphaTimer);
        }
        yield break;
    }
}
