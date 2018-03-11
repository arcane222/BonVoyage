using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpbarBehavior : MonoBehaviour {
    public GameObject playerObj;
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(playerObj.transform.position.x - 1, playerObj.transform.position.y + 0.75f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(playerObj.GetComponent<EnemyBehavior>().getHealth() / (float)playerObj.GetComponent<EnemyBehavior>().getMaxHealth(), 0.1f, 1);
    }
}
