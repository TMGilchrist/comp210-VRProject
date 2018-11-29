using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    //Array of array indices
    private int[,] neighbours;

    public int[,] Neighbours
    {
        get
        {
            return neighbours;
        }

        set
        {
            neighbours = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
