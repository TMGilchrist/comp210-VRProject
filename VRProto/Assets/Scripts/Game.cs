using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GridManager pinGrid;
    public HandManager hands;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        getHandInput();
	}

    void getHandInput()
    {
        if (hands.CheckHit() == true)
        {
            hands.CollisionObjectLeft.GetComponent<Transform>().Translate(0.0f, 10.0f,  0.0f);
        }
    }

}
