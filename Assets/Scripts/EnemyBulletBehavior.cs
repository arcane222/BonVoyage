using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : Projectile {
    public GameObject enemyObj, playerObj;
    int lifeTime = 0;

	// Use this for initialization
	void Start () {
        setPosition(enemyObj.transform.position.x, enemyObj.transform.position.y);
        this.gameObject.SetActive(onScreen);
        if (this.gameObject.name == "attack1.clone")
        {
            this.identity = 0;
            dmg = 2;
            spd = 10;
        }
        if (this.gameObject.name == "attack2.clone")
        {
            this.identity = 1;
            dmg = 2;
            spd = 10;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(spd * fx * Time.deltaTime, spd * fy * Time.deltaTime, 0));
	}

    public bool isMoving() {
        return onScreen;
    }

    public void setMoving(bool onScreen) {
        this.onScreen = onScreen;
        this.gameObject.SetActive(onScreen);
        if (onScreen) {
            x = enemyObj.transform.position.x;
            y = enemyObj.transform.position.y;

            transform.position = new Vector3(x, y, 1);
            Vector2 enemyPosition = new Vector2(enemyObj.transform.position.x, enemyObj.transform.position.y);
            Vector2 playerPosition = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y);
            calculateDirection(enemyPosition, playerPosition);     
            StartCoroutine(timer());
        }
    }

    //public void setCircularMoving(int idx, bool onScreen) {
    //    this.onScreen = onScreen;
    //    this.gameObject.SetActive(onScreen);
    //    int oneShooting = 10;
    //    if (onScreen)
    //    {
    //        x = enemyObj.transform.position.x;
    //        y = enemyObj.transform.position.y;
    //        transform.position = new Vector3(x, y, 1);

    //        //float angle = -135f;
    //        Vector2 enemyPosition = new Vector2(enemyObj.transform.position.x, enemyObj.transform.position.y);
    //        Vector2 playerPosition = new Vector2(playerObj.transform.position.x, playerObj.transform.position.y);
    //        //int counter = idx % 10;

    //        // float positionX = playerPosition.x * Mathf.Cos(angle + counter * 27) - playerPosition.y * Mathf.Sin(angle + counter * 27);
    //        //float positionY = playerPosition.x * Mathf.Sin(angle + counter * 27) + playerPosition.y * Mathf.Cos(angle + counter * 27);

    //        // Debug.Log("ply positionX: " + positionX + " ply positoinY: " + positionY);

    //        // Debug.Log("positionX: "+ positionX+" positoinY: "+positionY);

    //        // Vector2 circularBulletPosition = new Vector2(positionX, positionY);
    //        Vector2 circularBulletPosition = (new Vector2(Mathf.Cos(Mathf.PI * 2 * idx / oneShooting), spd*Mathf.Sin(Mathf.PI * idx * 2 / oneShooting)));
    //        fx = Mathf.Cos(Mathf.PI * 2 * idx / 10);
    //        fy = Mathf.Sin(Mathf.PI * idx * 2 / 10);
    //        //calculateDirection(enemyPosition, circularBulletPosition);
    //        StartCoroutine(timer());
    //        //원형으로 날아갈 총알의 목적지.
    //    }
    //}

    IEnumerator timer()
    {
        while (true)
        {
            lifeTime = lifeTime + 1;
            if (lifeTime == 3)
            {
                lifeTime = 0;
                setMoving(false);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.gameObject.name == "obstacle")
        {
            setMoving(false);
        }
        if (col2d.gameObject.name == "player")
        {
            setMoving(false);
        }
    }
}
