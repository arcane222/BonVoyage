using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : Projectile {
    public GameObject playerObj;
    int lifeTime = 0;

	void Start ()
    {
        setPosition(playerObj.transform.position.x, playerObj.transform.position.y);
        this.gameObject.SetActive(onScreen);
        if(this.gameObject.name == "bullet1.clone")
        {
            this.identity = 0;
            dmg = 2;
            spd = 10;
        }
        else if(this.gameObject.name == "bullet2.clone")
        {
            this.identity = 1;
            dmg = 4;
            spd = 15;
        }
        else if(this.gameObject.name == "bullet3.clone")
        {
            this.identity = 2;
            dmg = 6;
            spd = 20;
        }
	}
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(spd * fx * Time.deltaTime, spd * fy * Time.deltaTime, 0));
    }
    public bool isMoving()
    {
        return onScreen;
    }
    public void setMoving(bool onScreen)
    {
        this.onScreen = onScreen;
        this.gameObject.SetActive(onScreen);
        if (onScreen)
        {
            x = playerObj.transform.position.x;
            y = playerObj.transform.position.y;
            transform.position = new Vector3(x, y, 1);

            Vector2 playerPosition = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y);
            Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            calculateDirection(playerPosition,mousePosition);
            StartCoroutine(timer());
        }
    }
    IEnumerator timer()
    {
        while (true)
        {
            lifeTime = lifeTime + 1;
            if(lifeTime  == 3)
            {
                lifeTime = 0;
                setMoving(false);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if(col2d.gameObject.name == "obstacle")
        {
            setMoving(false);
        }
        if(col2d.gameObject.name == "enemy")
        {

        }
    }
}
