using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int identity;
    public float x, y, fx, fy, dmg, spd;
    public bool onScreen = false;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }
    public float getX()
    {
        return x;
    }
    public float getY()
    {
        return y;
    }
    public void setPosition(float x, float y)
    {
        this.x = x;
        this.y = y;
        transform.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.identity);
    }
    public void calculateDirection(Vector2 from, Vector2 to)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(to.x - from.x, 2) + Mathf.Pow(to.y - from.y, 2));
        fx = (to.x - from.x) / distance; //cos ceta
        fy = (to.y - from.y) / distance; //sin ceta
    }
}
