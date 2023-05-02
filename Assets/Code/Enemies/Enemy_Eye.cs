using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Eye : Enemy
{
    public GameObject fireballAttack;

    public override void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());

        animator.Play("Attack", -1, 0f);

        Instantiate(fireballAttack, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

        if(health <= 0)
        {
            StartCoroutine(Die());
        }
    }
}
