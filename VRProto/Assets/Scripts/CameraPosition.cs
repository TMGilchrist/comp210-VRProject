using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GridManager grid;
    public float Y;

    private Camera mainCamera;

	// Use this for initialization
	void Start ()
    {
        gameObject.transform.position = new Vector3(grid.gridX / 2, Y, grid.gridZ / 2);
        //mainCamera = gameObject.GetComponentInChildren<Camera>();
        //mainCamera.transform.position = new Vector3(grid.gridX / 2, Y, grid.gridZ / 2);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
