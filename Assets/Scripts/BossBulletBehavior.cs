using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletBehavior :Projectile //for test bullet
{
    public GameObject shooter;
    int lifeTime = 0;

    void Start()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
        setPosition(shooter.transform.position.x, shooter.transform.position.y);
        this.gameObject.SetActive(onScreen);
        if (this.gameObject.name == "boss_bullet.clone")
        {
            this.identity = 0;
            dmg = 2;
            spd = 10;
        }
    }
    void Update()
    {
        transform.Translate(new Vector3(spd * fx * Time.deltaTime, spd * fy * Time.deltaTime, 0));
    }
    public bool isMoving()
    {
        return onScreen;
    }

    public void setMoving(bool onScreen, float fx, float fy)
    {
        this.onScreen = onScreen;
        this.gameObject.SetActive(onScreen);
        if (onScreen)
        {
            x = shooter.transform.position.x;
            y = shooter.transform.position.y;

            transform.position = new Vector3(x, y, 1);
            this.fx = fx;
            this.fy = fy;
            StartCoroutine(timer());
        }

    }

    IEnumerator timer()
    {
        while (true)
        {
            lifeTime = lifeTime + 1;
            if (lifeTime == 3)
            {
                lifeTime = 0;
                setMoving(false, 0, 0);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
