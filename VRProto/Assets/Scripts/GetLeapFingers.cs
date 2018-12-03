/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/
// Original script: "MagneticPinch.cs" modified by unitycoder.com to just get the finger position & directions

using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;

public class GetLeapFingers : MonoBehaviour
{
    public HandModel hand_model;
    Hand leap_hand;

    void OnEnable()
    {
        Debug.Log(hand_model.fingers[0].name);
        //hand_model = GetComponent<HandModel>();
        leap_hand = hand_model.GetLeapHand();
        if (leap_hand == null) Debug.LogError("No leap_hand found");
    }


    void Update()
    {
    }


    /// <summary>
    /// Do a raycast from each finger of a hand.
    /// </summary>
    /// <param name="castDistance"> The distance the raycast should check.</param>
    /// <param name="rayIsEmpty"> If the ray is the 'empty' default ray that returns when no valid raycast hits.</param>
    /// <returns>A RaycastHit. If rayIsEmpty is false then this hit is the first hit from a finger onto an object.</returns>
    public RaycastHit RaycastFromFingers(float castDistance, out bool rayIsEmpty)
    {
        RaycastHit hit;
        bool raycastHit;

        //Iterate through each finger
        for (int i = 0; i < HandModel.NUM_FINGERS; i++)
        {
            FingerModel finger = hand_model.fingers[i]; //This is sometimes null? Apparently? Not sure why?

            // draw ray from finger tips (enable Gizmos in Game window to see)
            Debug.DrawRay(finger.GetTipPosition(), finger.GetRay().direction, Color.red);

            //Do actual raycast
            raycastHit = Physics.Raycast(finger.GetTipPosition(), finger.GetRay().direction, out hit, castDistance);

            if (raycastHit == true)
            {
                rayIsEmpty = false;
                return hit;
            }
        }

        rayIsEmpty = true;

        //Default raycast, should never actually be called
        raycastHit = Physics.Raycast(Vector3.zero, Vector3.one, out hit, castDistance);
        return hit;
    }


    public RaycastHit RaycastFromPalm(float castDistance, out bool rayIsEmpty)
    {
        RaycastHit hit;
        bool raycastHit;


        if (hand_model != null)
        {
            Transform palm = hand_model.palm; //This is sometimes null? Apparently? Not sure why?

            // draw ray from finger tips (enable Gizmos in Game window to see)
            Debug.DrawRay(palm.position, Vector3.down, Color.red);

            //Do actual raycast
            raycastHit = Physics.Raycast(palm.position, Vector3.down, out hit, castDistance);

            if (raycastHit == true)
            {
                rayIsEmpty = false;
                return hit;
            }
        }

        rayIsEmpty = true;

        //Default raycast, should never actually be called
        raycastHit = Physics.Raycast(Vector3.zero, Vector3.one, out hit, castDistance);
        return hit;
    }

    
    public RaycastHit RaycastFromFinger(float castDistance, out bool rayIsEmpty)
    {
        RaycastHit hit;

        bool raycastHit;
        FingerModel finger;

        if (hand_model != null)
        {
            //Debug.Log("Hand model not null");

            if (hand_model.fingers[1] != null)
            {
                //Debug.Log("Fingers not null");
            }
        }

        finger = hand_model.fingers[1]; //This is sometimes null? Apparently? Not sure why?

        // draw ray from finger tips (enable Gizmos in Game window to see)
        Debug.DrawRay(finger.GetTipPosition(), Vector3.down, Color.red);

        //Do actual raycast
        raycastHit = Physics.Raycast(finger.GetTipPosition(), finger.GetRay().direction, out hit, castDistance);

        if (raycastHit == true)
        {
            rayIsEmpty = false;
            return hit;
        }

        rayIsEmpty = true;

        //Default raycast, should never actually be called
        raycastHit = Physics.Raycast(Vector3.zero, Vector3.one, out hit, castDistance);
        return hit;
    }

}