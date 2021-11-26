using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    public GameObject icone;
    public GameObject carta;
    public GameObject healthBar;
    public GameObject hud;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            icone.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterLetter();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icone.SetActive(false);
        }
    }
    public void ExitLetter()
    {
        carta.SetActive(false);
        Time.timeScale = 1f;
        healthBar.SetActive(true);
        hud.SetActive(true);
    }

    public void EnterLetter()
    {
        Time.timeScale = 0f;
        healthBar.SetActive(false);
        carta.SetActive(true);
        hud.SetActive(false);
    }
}
