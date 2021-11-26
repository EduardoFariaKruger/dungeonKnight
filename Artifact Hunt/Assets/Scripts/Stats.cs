using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    public Animator anim;
    public int currentHealth { get; private set; }
    public HealthBar healthBar;
    public GameObject DeadScreen;
    public GameObject BarraDeVida;
    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Time.timeScale = 0f;
        DeadScreen.SetActive(true);
        BarraDeVida.SetActive(false);
    }
    public void Revive()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}