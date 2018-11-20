using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class HandManager : MonoBehaviour
{
    public HandModel leftHand;
    public HandModel rightHand;

    public float rayCastDistance;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    void CheckHit()
    {
        //Raycast from left hand
        leftHand.GetComponent<GetLeapFingers>().RaycastFromFingers(rayCastDistance);
    }

}
