using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMainA : BasicEnemyMain {

    public int aiRunToPlayer = 20;
    public int aiJumpToPlayer = 30;
    public int aiEscape = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void FixedUpdateAi()
    {
        switch (aiState) {
            case ENEMYSTATE.ACTIONSELECT:
                break;
            case ENEMYSTATE.WAIT:
                break;
            case ENEMYSTATE.RUNTOPLAYER:
                break;
            case ENEMYSTATE.ESCAPE:
                break;
        }
    }
}
