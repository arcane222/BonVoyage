//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///*bullet for boss*/
//public class Bullet : Projectile {
//    public float speed = 10f;
//    // Use this for initialization
//    void Start()
//    {
//        Destroy(gameObject, 3.0f);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //transform.position += transform.forward * Time.deltaTime * speed;
//        //transform.position += transform.up * Time.deltaTime * speed;
//        transform.Translate(new Vector3(speed * fx * Time.deltaTime, speed * fy * Time.deltaTime, 0));
//        //pos = transform.position;
//        //pos.y += Time.deltaTime * speed;
//        //pos.x += Time.deltaTime * speed;
//        //transform.position = pos;
//    }
//}
