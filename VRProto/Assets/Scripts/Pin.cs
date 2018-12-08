using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public List<GameObject> neighbours = new List<GameObject>();

    //If this object can exert magnetism on neighbours
    public bool magnetismActive = true;

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
                    //neighbour.GetComponent<Pin>().magnetismImmune = true;
                    //activate neighbour magnetism
                }
            }

            //magnetismActive = false; //maybe not deactivate?
            //magnetismImmune = true;
        }
	}

    public void UpdatePin( Vector3 direction, float maxHeight, float moveSpeed)
    {
        Debug.Log("Update pin called");
        if (magnetismActive)
        {
            foreach (GameObject neighbour in neighbours)
            {
                Debug.Log("Getting neighbour");
                if (neighbour.GetComponent<Pin>().magnetismImmune != true)
                {
                    //move neighbour
                    //movePin(neighbour, Vector3.up, maxHeight * 0.5f, moveSpeed * 0.8f);
                    neighbour.transform.position = new Vector3(neighbour.transform.position.x, this.transform.position.y -3, neighbour.transform.position.z);
                    //neighbour.GetComponent<Pin>().UpdatePin(Vector3.up, maxHeight * 2, moveSpeed * 0.5f);

                    //neighbour.GetComponent<Pin>().magnetismImmune = true;
                    //activate neighbour magnetism
                }
            }

            //magnetismActive = false; //maybe not deactivate?
            //magnetismImmune = true;
        }
    }




    public void movePin(GameObject pin, Vector3 direction, float maxHeight, float moveSpeed)
    {

        if (pin != null)
        {
            if (pin.transform.position.y <= maxHeight)
            {
                //Move the pin
                pin.GetComponent<Transform>().Translate(direction * Time.deltaTime * moveSpeed);

                //Activate magnetism of pin
                //pin.GetComponent<Pin>().magnetismActive = true;
            }
        }
    }


}
