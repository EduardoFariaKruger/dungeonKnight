using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicScript : MonoBehaviour
{
    [SerializeField] int magicDamage;
    Rigidbody2D rb;
    [SerializeField] float speed;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<TomarDano>().TakeDamage(magicDamage);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Scenario")
        {
            Destroy(this.gameObject);
        }
    }
}
