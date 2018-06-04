using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMYSTATE {
    ACTIONSELECT,//행동 선택
    WAIT,//멈춰서 대기
    RUNTOPLAYER,//가까워짐
    ESCAPE, //멀어짐
    ATTACK,//공격
    FREEZE //행동없이 이동
}

public class BasicEnemyMain : MonoBehaviour {
    public int debugState = -1;
    public ENEMYSTATE aiState = ENEMYSTATE.ACTIONSELECT;
    public float aiActionTime = 0.0f; //ai state의 한계시간.
    public float distanceToPlayer = 0.0f;
    public float distanceToPlayerPrev = 0.0f;
    public PlayerBehavior player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void FixedUpdate() {
        if (BeginEnemyAction()) {
            FixedUpdateAi();
            EndEnemyAction();
        }
    }

    public virtual void FixedUpdateAi() {

    }

    public bool BeginEnemyAction() {

        //적이 현재 살아있는지 확인.
        //적 컨트롤러 애니메이터 상태 트루.
        //상태검사
        if (!CheckAction()) {
            return false;
        }
        return true;
    }

    public bool CheckAction()
    { //애니메이터 상태확인.
        return true;
    }

    public void EndEnemyAction() {
        float time = Time.fixedTime - aiActionTime;
        if (time > aiActionTime) {
            aiState = ENEMYSTATE.ACTIONSELECT;
        }
    }


    public void SetAIState(ENEMYSTATE sts, float t) {
        aiState = sts;
        aiActionTime = Time.fixedTime;
        //캐릭터 컨트롤러 move 코드
    }

    public float GetDistancePlayer() {
        distanceToPlayerPrev = distanceToPlayer;
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        return distanceToPlayer;
    }

    public bool IsChangeDistancePlayer(float l) {
        return (Mathf.Abs(distanceToPlayer - distanceToPlayerPrev)>1);
    }
    public float GetDistancePlayerX() {
        Vector3 posA = transform.position;//적
        Vector3 posB = player.transform.position;//플레이어
        posA.y = 0;
        posA.z = 0;
        posB.y = 0;
        posB.z = 0;
        return Vector3.Distance(posA, posB);
    }

    public float GetDistancePlayerY() {
        Vector3 posA = transform.position;//적
        Vector3 posB = player.transform.position;//플레이어
        posA.x = 0;
        posA.z = 0;
        posB.x = 0;
        posB.y = 0;
        return Vector3.Distance(posA,posB);
    }
}
