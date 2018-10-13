using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public bool active = true;
    public int scene = 0;
    public float delay = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            StartCoroutine(transition());
        }
    }
    IEnumerator transition()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
