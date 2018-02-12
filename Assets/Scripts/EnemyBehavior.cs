using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour {
    public GameObject target; //for playerObj
    public GameObject bullet;
    public Transform bulletPrefab,shooter;
    GameObject[,] bulletArray = new GameObject[2, 50]; //two type bullet
    int health, maxHealth, gunType;
    float atkSpd = 0.5f;
    AudioClip shootSound;
    // Use this for initialization
    void Start () {
        health = 200;
        maxHealth = 200;
        atkSpd = 0.5f;
        for (int i = 0; i < 50; i++)
        {
            bulletArray[0, i] = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletArray[0, i].name = "attack1.clone";
        }

        //for (int i = 0; i < 50; i++)
        //{
        //    bullet[1, i] = Instantiate(bulletB, transform.position, Quaternion.identity);
        //    bullet[1, i].name = "attack2.clone";
        //}

        // StartCoroutine(shoot());
        //StartCoroutine(shootCircular());
        // StartCoroutine(timer());
        StartCoroutine(StartBulletPattern());
    }
	
	// Update is called once per frame
	void Update() {
        
	}

    IEnumerator shoot(float atkSpd)
    {
        while (true)
        {
            gunType = 0;
            //임시
                for (int i = 0; i < 50; i++)
                {
                    if (!bulletArray[gunType, i].GetComponent<EnemyBulletBehavior>().isMoving())
                    {
                    bulletArray[gunType, i].GetComponent<EnemyBulletBehavior>().setMoving(true);
                        //SoundManager.instance.RandomizeSfx(shootSound);
                        break;
                    }
                }
            yield return new WaitForSeconds(atkSpd);
        }
    }

    IEnumerator StartBulletPattern()
    {
        StartCoroutine(shoot(0.5f));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Spiral(shooter, bulletPrefab,20,2,0.1f,true));
        yield return new WaitForSeconds();
    }

    IEnumerator Spiral(Transform shooter, Transform bulletTrans, int shotNum, int volly, float shotTime, bool clockwise)
    {
        yield return new WaitForSeconds(shotTime);
    }

    //IEnumerator shootCircular()
    //{
    //    float angle = 180 / 10;

    //    // 저는 총알을 쏘는 갯수를 변수로 지정해서,
    //    do
    //    {
    //        gunType = 1;
    //        for (int i = 0; i < 50; i++)
    //        {
    //            //Debug.Log(i);
    //            if (!bullet[gunType, i].GetComponent<EnemyBulletBehavior>().isMoving())
    //            {
    //                bullet[gunType, i].GetComponent<EnemyBulletBehavior>().setCircularMoving(i, true);
    //                Debug.Log("i:" + i);
    //                //SoundManager.instance.RandomizeSfx(shootSound);
    //                break;
    //            }
    //            //GameObject obj;
    //            //obj = (GameObject)Instantiate(bullet, boss.transform.position, Quaternion.identity);

    //            //보스의 위치에 bullet을 생성합니다.
    //            //obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));


    //            // obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting - 90));
    //        }
    //        //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

    //        yield return new WaitForSeconds(0.5f);
    //    } while (true);
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("onTriggerEnemy");
        if (col.gameObject.name == "obstacle" || col.gameObject.name == "bullet1.clone")
        {
            Debug.Log("name:" + col.gameObject.name);
            health -= 20;
        }
    }
    public int getHealth()
    {
        return health;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
}
