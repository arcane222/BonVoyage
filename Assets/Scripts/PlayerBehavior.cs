using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public GameObject bullet1Obj, bullet2Obj, bullet3Obj, cameraObj;
    GameObject[ , ] bullet = new GameObject[3, 50];
    int health, maxHealth, guntype = 0;
    float x, y, movingSpd, atkSpd;
	// Use this for initialization
	void Start() {
        health = 100;
        maxHealth = 100;
        movingSpd = 5.0f;
        atkSpd = 0.5f;
        x = transform.position.x;
        y = transform.position.y;
        for (int i = 0; i < 50; i++)
        {
            bullet[0, i] = Instantiate(bullet1Obj, transform.position, Quaternion.identity);
            bullet[0, i].name = "bullet1.clone";
            bullet[1, i] = Instantiate(bullet2Obj, transform.position, Quaternion.identity);
            bullet[1, i].name = "bullet2.clone";
            bullet[2, i] = Instantiate(bullet3Obj, transform.position, Quaternion.identity);
            bullet[2, i].name = "bullet3.clone";
        }
        StartCoroutine(shoot());
        StartCoroutine(timer());
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.6f * movingSpd * Time.deltaTime, 0, 0));
            Debug.Log(movingSpd * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.6f * movingSpd * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0.6f * movingSpd * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -0.6f * movingSpd * Time.deltaTime, 0));
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            guntype += 1;
            if(guntype == 3)
            {
                guntype = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "obstacle")
        {
            health -= 5;
        }
    }

    void OnGUI()
    {
        GUIStyle guistyle = new GUIStyle(GUI.skin.box);
        guistyle.fontSize = 30;
        GUI.Box(new Rect(new Vector2(0, 0), new Vector2(200, 50)), "GunType : " + guntype, guistyle);
    }
    IEnumerator shoot()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                for (int i = 0; i < 50; i++)
                {
                    if (!bullet[guntype, i].GetComponent<BulletBehavior>().isMoving())
                    {
                        bullet[guntype, i].GetComponent<BulletBehavior>().setMoving(true);
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(atkSpd);
        }
    }
    IEnumerator timer()
    {
        while (true)
        {
            if(health < maxHealth)
            {
                health += 1;
            }
            yield return new WaitForSeconds(2f);
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
