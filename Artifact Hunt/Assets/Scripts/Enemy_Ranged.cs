using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged : MonoBehaviour
{

    [Header("Tiro")]
    public float fireRate = 1f;
    public float lineOfSite;
    public float shootingRange;
    private float nextFire;
    public Time time;
    [Space(10)]
    [Header("Movimentação")]
    public float speed;
    public Animator anim;
    public SpriteRenderer sp;
    [Space(10)]

    [Header("Referênicas")]
    public GameObject bullet;
    public GameObject bulletParent;
    public GameObject bulletParentLeft;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        anim.SetFloat("Time", Time.time);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer > lineOfSite)
        {
            anim.SetBool("ChaseLeft", false);
            anim.SetBool("ChaseRight", false);
        }
        if (distanceFromPlayer <= lineOfSite && player.transform.position.x > transform.position.x)
        {
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
            {
                anim.SetBool("ChaseRight", true);
                anim.SetBool("ChaseLeft", false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= shootingRange && nextFire < Time.time)
            {
                anim.SetTrigger("Attack");
                nextFire = Time.time + fireRate;
            }
        }
        else
        {
            if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
            {
                anim.SetBool("ChaseLeft", true);
                anim.SetBool("ChaseRight", false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= shootingRange && nextFire < Time.time)
            {
                anim.SetTrigger("Attack");
                nextFire = Time.time + fireRate;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    private void Magic()
    {
        Instantiate(bullet, bulletParentLeft.transform.position, Quaternion.identity);
    }
}
