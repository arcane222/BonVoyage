using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public GameObject bullet1Obj, bullet2Obj, bullet3Obj, cameraObj;
    GameObject[ , ] bullet = new GameObject[3, 50];
    int health, maxHealth, guntype = 0;
    float x, y, movingSpd, atkSpd;
    Animator animator;      //
    public AudioClip shootSound;
    public AudioClip voyagerSound1;
    public AudioClip voyagerSound2;
    bool isWalking = false;
    bool isDashing = false;
    float h; //horizontal - for animation
    float v; //vertical - for animation
    // Use this for initialization
    void Start() {
        health = 100;
        maxHealth = 100;
        movingSpd = 5.0f;
        atkSpd = 0.5f;
        isDashing = true;

        animator = GetComponent<Animator>();
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
        isWalking = false;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 xdir = new Vector3(h, 0, 0);
        Vector3 ydir = new Vector3(0, v, 0);
        Vector3 dir = xdir + ydir;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.6f * movingSpd * Time.deltaTime, 0, 0)); //0.6f는 해당 방향으로 프레임당 얼마씩 움직일지 정하는숫자.
            Debug.Log(movingSpd * Time.deltaTime);

            isWalking = true;
            animator.SetFloat("Direction_X", h);
            animator.SetFloat("Direction_Y", v);
            animator.SetBool("isWalking", isWalking);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.6f * movingSpd * Time.deltaTime, 0, 0));

            isWalking = true;
            animator.SetFloat("Direction_X", h);
            animator.SetFloat("Direction_Y", v);
            animator.SetBool("isWalking", isWalking);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0.6f * movingSpd * Time.deltaTime, 0));
            isWalking = true;
            animator.SetFloat("Direction_X", h);
            animator.SetFloat("Direction_Y", v);
            animator.SetBool("isWalking", isWalking);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -0.6f * movingSpd * Time.deltaTime, 0));
            isWalking = true;
            animator.SetFloat("Direction_X", h);
            animator.SetFloat("Direction_Y", v);
            animator.SetBool("isWalking", isWalking);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            guntype += 1;
            if(guntype == 3)
            {
                guntype = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SoundManager.instance.ChangeBgAudio(voyagerSound1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.instance.ChangeBgAudio(voyagerSound2);
            //SoundManager.instance.bgSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && isDashing) {
            // transform.SetPositionAndRotation(new Vector3(),Quaternion.identity);
            transform.Translate(0.6f*dir*10f); //FIXME
        }
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("onTriggerPlayer");
        if(col.gameObject.name == "obstacle" || col.gameObject.name == "attack1.clone")
        {
            //Debug.Log("puck");
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
                        SoundManager.instance.RandomizeSfx(shootSound);
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
            if (health < maxHealth)
            {
                health += 3;
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
    public bool getIsWalking() {
        return isWalking;
    }
}
