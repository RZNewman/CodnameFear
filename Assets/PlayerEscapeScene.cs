using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEscapeScene : MonoBehaviour {

    public player player;
    public int paranoiaLimit = 50;

	// Use this for initialization
	void Start () {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<player>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (player.paranoia >= paranoiaLimit)
        {
            StartCoroutine(ResetScene());
        }
	}

    public IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(3);
    }
}
