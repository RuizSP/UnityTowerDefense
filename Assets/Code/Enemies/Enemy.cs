using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int attack;
    public float moveSpeed = 1f;

    public Animator animator;
    public float attackInterval = 1f;
    Coroutine attackOrder;
    public bool collidingTower = false;

    public void Move()
    {
        animator.ResetTrigger("collidingTower");
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    public virtual void LoseHealth()
    {
        health--;
        StartCoroutine(BlinkRed());

        if(health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Projectile")
        {
            LoseHealth();
        }

        if(other.tag == "Tower")
        {
            collidingTower = true;
            animator.SetTrigger("collidingTower");

            StartCoroutine(Attack());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Tower")
        {
            collidingTower = false;
        }
    }

    public IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.2f);

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public IEnumerator Die()
    {
        GetComponent<SpriteRenderer>().color = Color.black;

        GetComponent<Collider2D>().enabled = false;
        moveSpeed = 0f;

        animator.Play("Die");

        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!collidingTower)
        {
            Move();
        }
    }

    IEnumerator Attack()
    {
        animator.Play("Attack", -1, 0f);

        //Inserir aqui dano na torre
        towerBehavior.danoCounter(attack);

        yield return new WaitForSeconds(attackInterval);

        StartCoroutine("Attack");
    }
}
