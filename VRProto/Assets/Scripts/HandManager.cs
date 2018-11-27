﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class HandManager : MonoBehaviour
{
    public HandModel leftHand;
    public HandModel rightHand;

    public float rayCastDistance;

    private bool rayIsEmpty;
    private RaycastHit hit;
    private GameObject collisionObjectLeft;
    private GameObject collisionObjectRight;

    public GameObject CollisionObjectLeft
    {
        get
        {
            return collisionObjectLeft;
        }

        set
        {
            collisionObjectLeft = value;
        }
    }

    public GameObject CollisionObjectRight
    {
        get
        {
            return collisionObjectRight;
        }

        set
        {
            collisionObjectRight = value;
        }
    }


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //CheckHit();
	}


    public bool CheckHit()
    {
        Debug.Log("Checking for hit now.");
        //Left hand raycasting
        if (leftHand.enabled == true)
        {
            Debug.Log("Do raycast");
            //Raycast from left hand and check for a hit
            hit = leftHand.GetComponent<GetLeapFingers>().RaycastFromFingers(rayCastDistance, out rayIsEmpty);

            //Check that a valid raycast was returned
            if (rayIsEmpty != true)
            {
                //Check for valid collision
                if (hit.collider != null)
                {
                    CollisionObjectLeft = hit.collider.gameObject;
                    return true;
                }
            }
        }

        //Right hand raycasting
        if (rightHand.enabled == true)
        {
            Debug.Log("Do raycast");
            //Raycast from left hand and check for a hit
            hit = rightHand.GetComponent<GetLeapFingers>().RaycastFromFingers(rayCastDistance, out rayIsEmpty);

            //Check that a valid raycast was returned
            if (rayIsEmpty != true)
            {
                //Check for valid collision
                if (hit.collider != null)
                {
                    CollisionObjectRight = hit.collider.gameObject;
                    return true;
                }
            }
        }

        return false;

    }

}
