using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoyagerBehavior : MonoBehaviour {

    public GameObject target;

    private float y = 1.0f; // 높이 즉 y값
    private float x = 1.0f; // x값
    public float movingSpeed = 1f;  // 따라가는 속도

    // Use this for initialization
    void Start () {
        //transform.SetPositionAndRotation(new Vector3(target.transform.position.x - 3, target.transform.position.y - 3,0),Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.SetPositionAndRotation(new Vector3(target.transform.position.x, transform.position.y, 0), Quaternion.identity);
        Vector3 to = target.transform.position + new Vector3(x, y, 0); // 타겟포지션에 일정거리만큼 떨어진 값을 더해서 이동할 위치를 구함.
        transform.position = Vector3.Lerp(transform.position, to, Time.deltaTime * movingSpeed); //lerp를 이용해서 대상과 보이저 사이의 포지션 값 보정.
    }
    /*참고 : http://apptowns.blogspot.kr/2013/06/ywfollowpetcs.html?m=1*/

}
