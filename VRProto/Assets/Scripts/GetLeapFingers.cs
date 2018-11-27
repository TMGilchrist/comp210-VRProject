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
    HandModel hand_model;
    Hand leap_hand;

    void Start()
    {
        hand_model = GetComponent<HandModel>();
        leap_hand = hand_model.GetLeapHand();
        if (leap_hand == null) Debug.LogError("No leap_hand found");
    }


    void Update()
    {
        //RaycastFromFingers(10, );
    }



    public RaycastHit RaycastFromFingers(float castDistance, out bool rayIsEmpty)
    {
        RaycastHit hit;
        bool raycastHit;

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


}