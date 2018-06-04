using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 적 기본 액션컨트롤러*/
public class BasicCharacterController : MonoBehaviour {

    public float dir = 1.0f;
    public float speedVx = 0.0f;
    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void ActionMove(float n) {
        if (n != 0.0f){
            dir = Mathf.Sign(n);
            speedVx = speedVx * n;
            animator.SetTrigger("run");
        }
        else {
            speedVx = 0;
            animator.SetTrigger("Idle");
        }
    }

    public bool ActionLookup(GameObject go, float near) {   //방향을 타겟방향으로 
        if (Vector3.Distance(transform.position, go.transform.position) > near) {
            dir = (transform.position.x < go.transform.position.x) ? +1 : -1; //아마 횡스크롤이라 이렇게만 해놓은듯.
            return true;
        }
        return false;
    }

    public bool ActionMoveToNear(GameObject go, float near) { //타겟으로 다가감.
        if (Vector3.Distance(transform.position, go.transform.position) > near) {
            ActionMove((transform.position.x < go.transform.position.x)? +1.0f : -1.0f);
            return true;
        }
        return false;
    }

    public bool ActionMoveToFar(GameObject go, float far) { //타겟에서 멀어짐
        if (Vector3.Distance(transform.position, go.transform.position)<far) {
            ActionMove((transform.position.x > go.transform.position.x) ? +1.0f : -1.0f);
            return true;
        }
        return false;
    }
    
}