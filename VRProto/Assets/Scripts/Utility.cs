using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{

    public enum Handedness { Left, Right };

    /// <summary>
    /// Raise a pin on the gameboard.
    /// </summary>
    /// <param name="pin"> The pin in the grid to move.</param>
    public void raisePin(GameObject pin, float maxHeight, float moveSpeed)
    {

        if (pin != null)
        {
            if (pin.transform.position.y <= maxHeight)
            {
                //Move the pin
                pin.GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime * moveSpeed);

                //Activate magnetism of pin
                pin.GetComponent<Pin>().magnetismActive = true;
            }
        }
    }

}
