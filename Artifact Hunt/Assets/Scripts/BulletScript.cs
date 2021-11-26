using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    GameObject target;
    public GameObject player;
    Rigidbody2D rb;
    public float speed;
    public int bulletDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 MoveDir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(MoveDir.x, MoveDir.y);
        Destroy(this.gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Stats>().TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }

    }

}
