using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom_Mini : Enemy
{
    public override void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());

        if(health <= 0)
        {
            StartCoroutine(Die());
        }
    }
}
