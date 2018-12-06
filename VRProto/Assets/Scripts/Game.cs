﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GridManager pinGrid;
    public HandManager hands;

    //The amount that a pin is raised
    public float raiseHeight = 10;
    public float raiseSpeed = 10;

    private Vector3 upVector = new Vector3(0.0f, 1.0f, 0.0f);

    //The object that is currently interactable
    private GameObject activeObjectLeft;
    private GameObject activeObjectRight;

    //Index of the currently active object in the grid
    private int[] activeObjectIndex;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        getHandInput();
	}

    /// <summary>
    /// Check for input from the player's hands in the form of sucessful raycasts.
    /// </summary>
    void getHandInput()
    {
        if (hands.CheckHit() == true)
        {
            activeObjectLeft = hands.CollisionObjectLeft;
            activeObjectRight = hands.CollisionObjectRight;
            raisePin(activeObjectLeft);
            raisePin(activeObjectRight);

        }
    }

    /// <summary>
    /// Raise a pin on the gameboard.
    /// </summary>
    /// <param name="pin"> The pin in the grid to move.</param>
    void raisePin(GameObject pin)
    {

        if (pin != null)
        {
            if (pin.transform.position.y <= raiseHeight)
            {
                pin.GetComponent<Transform>().Translate(upVector * Time.deltaTime * raiseSpeed);

                activeObjectIndex = GetIndex(pinGrid.pinGrid, pin);
            }
        }                     
    }


    /// <summary>
    /// Method to find the index of an item contained in a 2D array and return it in an array.
    /// Access index with var = GetIndex()[0]; where 0 = x index and 1 = y index.
    /// </summary>
    /// <param name of array containing item="arrayName"></param>
    /// <param item to find the index of="searchItem"></param>
    /// <returns>An array containing the x and y values of the item's index</returns>
    public int[] GetIndex(GameObject[,] arrayName, GameObject searchItem)
    {
        int[] index = new int[2];

        //Iterate through array until gameobject matches search item
        for (int x = 0; x < arrayName.GetLength(0); x++)
        {
            for (int y = 0; y < arrayName.GetLength(1); y++)
            {
                if (arrayName[x, y] == searchItem)
                {
                    index[0] = x;
                    index[1] = y;

                    break;
                }
            }
        }

        return index;
    }

}
