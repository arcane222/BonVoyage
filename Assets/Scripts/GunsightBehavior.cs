using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsightBehavior : MonoBehaviour {

    public float speed;
    // Use this for initialization
    void Start () {
        speed = 60f;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        Vector3 target = getMousePosition();
        transform.position = Vector3.MoveTowards(transform.position, target, step);
	}

    Vector3 getMousePosition() {
        Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
        return mousePosition;
    }
}
