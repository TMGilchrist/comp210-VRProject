using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //Dimensions of the grid to create
    public int gridX;
    public int gridZ;

    //The object to use for the pin
    public GameObject pin;

    //The grid of pins
    public GameObject[,] pinGrid;

    public float gridScale = 0.1f;


	// Use this for initialization
	void Start ()
    {
        pinGrid = new GameObject[gridX, gridZ];

        CreateGrid();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void CreateGrid()
    {
        Vector3 position = new Vector3(0, 0, 0);
        GameObject newPin;

        //Create each item and insert into array
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                //Create new pin
                /* newPin = Instantiate(pin);

                 //Update position based on position in array - this should be done in the instantation.
                 position.Set(x, 0, z);
                 newPin.GetComponent<Transform>().position = position;

                 //Set its parent to the gridManager
                 newPin.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();*/

                //Add new pin to the array

                newPin = CreatePin(x, z);
                pinGrid[x, z] = newPin;

            }
        }

        this.transform.localScale = new Vector3(gridScale, gridScale, gridScale);
    }

    GameObject CreatePin(int x, int z)
    {
        Vector3 position = new Vector3(0, 0, 0);
        GameObject newPin;

        //Create new pin
        newPin = Instantiate(pin);

        //Update position based on position in array - this should be done in the instantation.
        position.Set(x, 0, z);
        newPin.GetComponent<Transform>().position = position;

        //Set its parent to the gridManager
        newPin.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();

        //Check each neighbour position
        for (int X = 0; X < 3; X++)
        {
            for (int Z = 0; Z < 3; Z++)
            {
                //Debug.Log(X + ", " + Z);
            }
        }

        //newPin.GetComponent<Pin>().Neighbours

        return newPin;
    }



}
