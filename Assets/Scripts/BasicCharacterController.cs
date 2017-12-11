/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof (BasicAnimationController))]
public class BasicCharacterController : MonoBehaviour {

    private BasicAnimationController character;

    private void Awake()
    {
        character = GetComponent<BasicAnimationController>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool isWalking = false;
        if (h > 0)
        {
     
        }
        else if(h < 0) {
    
        } else if(v > 0) {
          
        } else if(v < 0) {
          
        } else {
            isWalking = false;
        }

        Debug.Log(isWalking);
        character.Move(h, v,isWalking);
    }
}
*/