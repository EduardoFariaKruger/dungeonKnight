using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TomarDano : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    private int currentHealth;
    private Animator anim;
    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hurt");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
