using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchlightMovingWhite : MonoBehaviour {

    public Vector3 point1 = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 point2 = new Vector3(0.0f, 0.0f, 0.0f);
    public Transform transformToMove;
    public int moveCounter = 0;
    public int moveCounterMax = 20;
    public bool movingUpBool = true;
    public float moveStepTime = 0.2f;

    // Use this for initialization
    void Start () {
        StartCoroutine(StartMoving());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartMoving()
    {
        if (movingUpBool)
        {
            StartCoroutine(MoveUp(moveCounter));
        }
        else
        {
            StartCoroutine(MoveDown(moveCounter));
        }
        yield return null;
    }

    private IEnumerator MoveUp(int start)
    {
        Debug.Log("SearchlightMovingWhite MoveUp() moveCounter " + moveCounter);
        movingUpBool = true;
        for (int i = start; i <= moveCounterMax; i++)
        {
            transformToMove.position = Vector3.Lerp(point1, point2, (float)i / (float)(moveCounterMax));
            moveCounter = i;
            yield return new WaitForSeconds(moveStepTime);
        }
        StartCoroutine(MoveDown(moveCounter));
    }

    private IEnumerator MoveDown(int start)
    {
        Debug.Log("SearchlightMovingWhite MoveDown() moveCounter " + moveCounter);
        movingUpBool = false;
        for (int i = start; i >= 0; i--)
        {
            transformToMove.position = Vector3.Lerp(point1, point2, (float)i / (float)(moveCounterMax));
            moveCounter = i;
            yield return new WaitForSeconds(moveStepTime);
        }
        StartCoroutine(MoveUp(moveCounter));
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
            StartCoroutine(StartMoving());
        }
    }
}
