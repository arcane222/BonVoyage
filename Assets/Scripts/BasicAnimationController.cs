/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimationController : MonoBehaviour { //BaseMotionController

    private Animator anim;
    //private Rigidbody2D rigidbody;

    [SerializeField]
    private float speed = 7.0f;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        //rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float h, float v,bool isWalking)//horizontal, vertical 오른쪽:A 왼쪽:D 위:W 아래:D
    {
        //Vector2 direction = new Vector2(h,v).normalized;
        //rigidbody.velocity = direction * speed;
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("Direction_X", h);
        anim.SetFloat("Direction_Y", v);
        
    }
}
*/