using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactible : MonoBehaviour
{

    [SerializeField] private string nextLevel;
    [SerializeField] private GameObject Icone;
    [SerializeField] private GameObject endPhase;
    [SerializeField] private GameObject healthBar;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Icone.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0f;
                healthBar.SetActive(false);
                endPhase.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Icone.SetActive(false);
        }
    }

}
