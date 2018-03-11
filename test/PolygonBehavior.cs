using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonBehavior : MonoBehaviour {

    private Vector2 worldMousePosition;
    private float distance, spd;
    private int identity;
	// Use this for initialization
	void Start () {
        if(gameObject.name == "polygon0")
        {
            identity = 0;
        }
        else if(gameObject.name == "polygon1")
        {
            identity = 1;
        }
        else if(gameObject.name == "polygon2")
        {
            identity = 2;
        }
        spd = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            distance = Mathf.Sqrt(Mathf.Pow(worldMousePosition.x - transform.position.x, 2) + Mathf.Pow(worldMousePosition.y - transform.position.y, 2));
        }
        if(distance > 0)
        {
            calculateDirection();
            distance = Mathf.Sqrt(Mathf.Pow(worldMousePosition.x - transform.position.x, 2) + Mathf.Pow(worldMousePosition.y - transform.position.y, 2));
        }
    }

    void calculateDirection()
    {
        float fx = 0, fy = 0;
        if (distance > 0)
        {
            fx = spd * Time.deltaTime * (worldMousePosition.x - transform.position.x) / distance;
            fy = spd * Time.deltaTime * (worldMousePosition.y - transform.position.y) / distance;
        }
        if((fx > 0 && transform.position.x + fx > worldMousePosition.x) || (fx < 0 && transform.position.x + fy < worldMousePosition.x))
        {
            fx = worldMousePosition.x - transform.position.x;
        }
        if((fy > 0 && transform.position.y + fy > worldMousePosition.y) || (fy < 0 && transform.position.y + fy < worldMousePosition.y))
        {
            fy = worldMousePosition.y - transform.position.y;
        }
        transform.Translate(new Vector3(fx, fy, 0));
    }
    public int getIdentity()
    {
        return identity;
    }
}
