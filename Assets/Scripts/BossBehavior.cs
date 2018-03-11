using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject boss;
    public GameObject bullet;
    GameObject[,] bulletArray = new GameObject[1, 50];
    public float speed = 2f;
    float oneShoting = 50f;
    int bulletType = 0;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            bulletArray[0, i] = Instantiate(bullet, boss.transform.position, Quaternion.identity);
            bulletArray[0, i].name = "boss_bullet.clone";
        }
        StartCoroutine(StartBulletPattern());
    }

    void Update()
    {
    }

    IEnumerator StartBulletPattern()
    {
        StartCoroutine(Blast());
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator Blast()
    {
        float angle = 360 / oneShoting;
        do
        {
            for (int i = 0; i < oneShoting; i++)
            {
                Debug.Log(i);
                //obj = (GameObject)Instantiate(bullet, boss.transform.position, Quaternion.identity);
                if (!bulletArray[bulletType, i].GetComponent<BossBulletBehavior>().isMoving())
                {
                    float fx = Mathf.Cos(Mathf.PI * 2 * i / oneShoting);
                    float fy = Mathf.Sin(Mathf.PI * i * 2 / oneShoting);
                    bulletArray[bulletType, i].GetComponent<BossBulletBehavior>().setMoving(true, fx, fy);
                    //bulletArray[bulletType, i].transform.SetPositionAndRotation(new Vector3(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting),
                    //    speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)),Quaternion.identity);
                    //SoundManager.instance.RandomizeSfx(shootSound);
                    bulletArray[bulletType, i].transform.Rotate(new Vector3(0f, 0f, 360 * i / oneShoting - 90));
                    yield return new WaitForSeconds(.1f); //이코드를 빼면 원형으로 발사, 있을 경우 1초간격으로 회오리처럼 발사됨.
                    //break;  //이걸 넣으니까 하나씩만 나갑니다..
                }
                //보스의 위치에 bullet을 생성합니다.
                // bulletArray[bulletType, i].GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
                //bulletArray[bulletType, i].GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), 
                //    speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
                Debug.Log("Blast");
            }

            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.

            yield return new WaitForSeconds(1f);
        } while (true);
    }
}
