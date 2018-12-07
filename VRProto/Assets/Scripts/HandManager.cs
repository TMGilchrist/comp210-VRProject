using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class HandManager : MonoBehaviour
{
    public HandModel leftHand;
    public HandModel rightHand;

    //How far to raycast
    public float rayCastDistance;

    //If the ray being returned is an empty default ray and should be ignored.
    private bool rayIsEmpty;

    //
    public bool palmIsDownLeft;
    public bool palmIsDownRight;

    //The raycast hit from one of the hands.
    private RaycastHit hit;

    //Distance of the left and right hand raycast hits
    private float hitDistanceLeft;
    private float hitDistanceRight;

    //If a raycast has been successful
    private bool successfulHit = false;

    //The objects the left and right hands are interacting with.
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

    public float HitDistanceLeft
    {
        get
        {
            return hitDistanceLeft;
        }

        set
        {
            hitDistanceLeft = value;
        }
    }

    public float HitDistanceRight
    {
        get
        {
            return hitDistanceRight;
        }

        set
        {
            hitDistanceRight = value;
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
        successfulHit = false;

        //Left hand raycasting
        if (leftHand.isActiveAndEnabled == true)
        {
            //Raycast from left hand and check for a hit
            hit = leftHand.GetComponent<GetLeapFingers>().RaycastFromPalm(rayCastDistance, Utility.Handedness.Left, out palmIsDownLeft, out rayIsEmpty);
            //hit = leftHand.GetComponent<GetLeapFingers>().RaycastFromFinger(rayCastDistance, out rayIsEmpty);

            //Check that a valid raycast was returned
            if (rayIsEmpty != true)
            {
                //Check for valid collision
                if (hit.collider != null)
                {
                    //Debug.Log("Left hand raycast hit.");
                    CollisionObjectLeft = hit.collider.gameObject;
                    HitDistanceLeft = hit.distance;
                    //return true;
                    successfulHit = true;
                }
            }
        }


        //Right hand raycasting
        if (rightHand.isActiveAndEnabled == true)
        {
            //Raycast from left hand and check for a hit
            hit = rightHand.GetComponent<GetLeapFingers>().RaycastFromPalm(rayCastDistance,  Utility.Handedness.Right, out palmIsDownRight, out rayIsEmpty);
            //hit = rightHand.GetComponent<GetLeapFingers>().RaycastFromFinger(rayCastDistance, out rayIsEmpty);

            //Check that a valid raycast was returned
            if (rayIsEmpty != true)
            {
                //Check for valid collision
                if (hit.collider != null)
                {
                    //Debug.Log("Right hand raycast hit.");
                    CollisionObjectRight = hit.collider.gameObject;
                    HitDistanceRight = hit.distance;
                    //return true;
                    successfulHit = true;
                }
            }
        }

        return successfulHit;

    }



}
