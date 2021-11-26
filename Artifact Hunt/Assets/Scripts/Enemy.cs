using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public GameObject target;
    public Animator anim;
    public float speed;
    public float lineOfSite;
    public float minDistance;
    public int damage;
    public float attackSpeed;
    float attackCooldown;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer > lineOfSite)
        {
            anim.SetBool("ChaseLeft", false);
            anim.SetBool("ChaseRight", false);
        }
        if (distanceFromPlayer < lineOfSite && player.transform.position.x > transform.position.x)
        {
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > minDistance)
            {
                anim.SetBool("ChaseRight", true);
                anim.SetBool("ChaseLeft", false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            if (attackCooldown <= 0f && distanceFromPlayer <= minDistance)
            {
                anim.SetTrigger("Attack");
                attackCooldown = 1f / attackSpeed;
            }
        }
        else
        {
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > minDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
                anim.SetBool("ChaseLeft", true);
                anim.SetBool("ChaseRight", false);
            }
            if (attackCooldown <= 0f && distanceFromPlayer <= minDistance)
            {
                anim.SetTrigger("Attack");
                attackCooldown = 1f / attackSpeed;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, minDistance);
    }
    public void AttackPlayer()
    {
        target.GetComponent<Stats>().TakeDamage(damage);
    }
}