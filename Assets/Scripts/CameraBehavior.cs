using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    public GameObject playerObj;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, -10);
    }
}
