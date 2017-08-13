using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding2D : MonoBehaviour {

    public GameObject mover, obstacle;
    private Vector2 destination;
    private bool isMoving = false;
    struct locationInfo
    {
        public Vector2 position;
        public float f, g, h;
    }
    private locationInfo[] direction8 = new locationInfo[8];
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving)
        {

        }
	}

    bool getMoving()
    {
        return isMoving;
    }
    void setMoving(bool isMoving)
    {
        this.isMoving = isMoving;
    }

    Vector2 getDestination()
    {
        return destination;
    }

    void setDestination(Vector2 destination)
    {
        this.destination = destination;
    }
}
