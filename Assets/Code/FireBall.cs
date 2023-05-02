using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float fireballSpeed = 4f;
    public int fireballDamage = 100;
    private void Update()
    {
        transform.Translate(-transform.right * fireballSpeed * Time.deltaTime);
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().flipX = true;        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Tower")
        {
            //causa dano na vida da torre
            towerBehavior.danoCounter(fireballDamage);
            Destroy(gameObject);
        }
    }
}
