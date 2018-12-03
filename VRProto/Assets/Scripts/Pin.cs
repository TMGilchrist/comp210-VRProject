using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    //Array of array indices
    /*private int[,] neighbours;

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
    }*/


    public List<GameObject> neighbours = new List<GameObject>();

    //If this object can exert magnetism on neighbours
    public bool magnetismActive;

    //If this object is immune to magnetic forces
    public bool magnetismImmune;

    //The strength of this objects magnetism
    public float magnetismStrength;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (magnetismActive)
        {
            foreach (GameObject neighbour in neighbours)
            {
                if (neighbour.GetComponent<Pin>().magnetismImmune != true)
                {
                    //move neighbour
                    neighbour.GetComponent<Pin>().magnetismImmune = true;
                }
            }

            magnetismActive = false; //maybe not deactivate?
            magnetismImmune = true;
        }
	}
}
