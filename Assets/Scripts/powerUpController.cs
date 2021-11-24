using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpController : MonoBehaviour
{
    public Vector3 springer;
    public float timeSmooth;
    public Vector3 startPos;

    int timer;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // MoveObj();
	}


    void MoveObj()
    {
        
        Vector3 locPos = startPos + springer;
        Vector3 smooth = Vector3.Lerp(startPos, locPos, timeSmooth * Time.deltaTime);
        transform.position = smooth;

        if (transform.position==locPos)
        {
           Vector3 smoothNeg = Vector3.Lerp(startPos, -locPos, timeSmooth * Time.deltaTime);
           transform.position = smoothNeg;
        }
        
    }
}
