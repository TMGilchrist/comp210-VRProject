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
                newPin = CreatePin(x, z);
                pinGrid[x, z] = newPin;

            }
        }

        this.transform.localScale = new Vector3(gridScale, gridScale, gridScale);

        //Add pin neighbours
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                AddNeighbours(pinGrid[x, z].GetComponent<Pin>(), x, z);
            }
        }
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

        return newPin;
    }

    void AddNeighbours(Pin pin, int x, int z)
    {
        /*----------------------------
          I am so sorry for this mess.
          -----------------------------*/

        //Check left of grid
        if (x - 1 >= 0)
        {
            pin.neighbours.Add(pinGrid[x - 1, z]);
        }

        //Check left and bottom of grid
        if ((x - 1 >= 0) && (z - 1 >= 0))
        {
            pin.neighbours.Add(pinGrid[x - 1, z - 1]);
        }

        //Check left and top of grid
        if ((x - 1 >= 0) && (z + 1 < pinGrid.GetLength(1)))
        {
            pin.neighbours.Add(pinGrid[x - 1, z + 1]);
        }

        //Check bottom of grid
        if ((z - 1 >= 0))
        {
            pin.neighbours.Add(pinGrid[x, z - 1]);
        }

        //Check top of grid
        if (z + 1 < pinGrid.GetLength(1))
        {
            pin.neighbours.Add(pinGrid[x, z + 1]); //Sometimes throws an error not finding an object at this position?
        }

        //Check right and top of grid
        if ((x + 1 < pinGrid.GetLength(0)) && (z + 1 < pinGrid.GetLength(1)))
        {
            pin.neighbours.Add(pinGrid[x + 1, z + 1]);
        }

        //Check right of grid
        if (x + 1 < pinGrid.GetLength(0))
        {
            pin.neighbours.Add(pinGrid[x + 1, z]);
        }

        //Check right and bottom of grid
        if ((x + 1 < pinGrid.GetLength(0)) && (z - 1 >= 0))
        {
            pin.neighbours.Add(pinGrid[x + 1, z - 1]);
        }
    }
}
