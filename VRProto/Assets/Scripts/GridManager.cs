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
    private GameObject[,] pinGrid;


	// Use this for initialization
	void Start ()
    {
        CreateGrid();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void CreateGrid()
    {
        Vector3 position = new Vector3(0, 0, 0);

        //Create each item and insert into array
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                GameObject newPin = Instantiate(pin);
                position.Set(x, 0, z);
                newPin.GetComponent<Transform>().position = position;

                pinGrid[x, z] = newPin;


            }
        }
    }

}
