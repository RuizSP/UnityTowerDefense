using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom : Enemy
{
    public GameObject miniMush;

    public override void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());

        if(health <= 0)
        {
            Instantiate(miniMush, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            StartCoroutine(Die());
        }
    }
}
