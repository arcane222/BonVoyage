using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    public GameObject target;
    private float distance, spd;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);
	}
	
	// Update is called once per frame
	void Update () {
        distance = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2));
        if(distance > 0)
        {
            calculateDirection();
        }
    }
    void calculateDirection()
    {
        float fx = 0, fy = 0;
        if (distance > 0)
        {
            if(distance > 0.5)
            {
                spd = 5.0f;
            }
            else
            {
                spd = 3.0f;
            }
            fx = spd * Time.deltaTime * (target.transform.position.x - transform.position.x) / distance;
            fy = spd * Time.deltaTime * (target.transform.position.y - transform.position.y) / distance;
        }
        if ((fx > 0 && transform.position.x + fx > target.transform.position.x) || (fx < 0 && transform.position.x + fy < target.transform.position.x))
        {
            fx = target.transform.position.x - transform.position.x;
        }
        if ((fy > 0 && transform.position.y + fy > target.transform.position.y) || (fy < 0 && transform.position.y + fy < target.transform.position.y))
        {
            fy = target.transform.position.y - transform.position.y;
        }
        transform.Translate(new Vector3(fx, fy, 0));
    }
}
