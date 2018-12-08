using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
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
                    //activate neighbour magnetism
                }
            }

            magnetismActive = false; //maybe not deactivate?
            magnetismImmune = true;
        }
	}


    public void movePin(GameObject pin, float maxHeight, float moveSpeed)
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
