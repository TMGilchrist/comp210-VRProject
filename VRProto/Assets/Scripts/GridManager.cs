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
                Debug.Log("Create new pin");
                newPin = Instantiate(pin);

                //Update position based on position in array
                position.Set(x/2, 0, z/2);
                newPin.GetComponent<Transform>().position = position;

                //Set its parent to the gridManager
                newPin.GetComponent<Transform>().parent = gameObject.GetComponent<Transform>();

                //Add new pin to the array
                pinGrid[x, z] = newPin;
                Debug.Log("Array at position " + x + ", " + z + " : " + pinGrid[x, z]);

            }
        }
    }

}
