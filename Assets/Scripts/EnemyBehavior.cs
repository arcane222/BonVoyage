using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {
    public GameObject target; //for playerObj
    public GameObject bulletA;
    GameObject[,] bullet = new GameObject[1, 50];
    int health, gunType = 0;
    float atkSpd = 0.5f;
    AudioClip shootSound;
    // Use this for initialization
    void Start () {
        health = 100;
        atkSpd = 0.5f;
        for (int i = 0; i < 50; i++)
        {
            bullet[0, i] = Instantiate(bulletA, transform.position, Quaternion.identity);
            bullet[0, i].name = "attack1.clone";
        }
        StartCoroutine(shoot());
       // StartCoroutine(timer());
    }
	
	// Update is called once per frame
	void Update() {
        
	}

    IEnumerator shoot()
    {
        while (true)
        {
            //임시
                for (int i = 0; i < 50; i++)
                {
                    if (!bullet[gunType, i].GetComponent<EnemyBulletBehavior>().isMoving())
                    {
                        bullet[gunType, i].GetComponent<EnemyBulletBehavior>().setMoving(true);
                        //SoundManager.instance.RandomizeSfx(shootSound);
                        break;
                    }
                }
            yield return new WaitForSeconds(atkSpd);
        }
    }

}
