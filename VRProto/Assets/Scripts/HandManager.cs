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

    private bool rayIsEmpty;
    private RaycastHit hit;
    private float hitDistanceLeft;
    private float hitDistanceRight;

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
            hit = leftHand.GetComponent<GetLeapFingers>().RaycastFromFinger(rayCastDistance, out rayIsEmpty);

            //Check that a valid raycast was returned
            if (rayIsEmpty != true)
            {
                //Check for valid collision
                if (hit.collider != null)
                {
                    Debug.Log("Left hand raycast hit.");
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
            hit = rightHand.GetComponent<GetLeapFingers>().RaycastFromFinger(rayCastDistance, out rayIsEmpty);

            //Check that a valid raycast was returned
            if (rayIsEmpty != true)
            {
                //Check for valid collision
                if (hit.collider != null)
                {
                    Debug.Log("Right hand raycast hit.");
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
