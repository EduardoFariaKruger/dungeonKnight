using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("movimentação")]
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed;
    public Camera cam;
    [Space(10)]
    [Header("Ataque")]
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    float nextAttackTime = 0f;
    [Space(10)]
    [Header("Dash")]
    private float nextDash;
    public float dashRate = 1;
    public float dashDistance;
    [Space(10)]
    [Header("Magic")]
    public Transform magicPoint;
    public float magicRate = 2f;
    float nextMagicTime;
    public GameObject magia;
    public float magicSpeed;
    [Space(10)]
    [Header("Equipment")]
    Vector2 mousePos;
    private bool magicSelected = false;
    private bool canMagic = false;
    public GameObject swordIcon;
    public GameObject magicIcon;
    public GameObject mãoEspada;
    public GameObject mãoMagia;
    public Transform magicHand1;
    public SpriteRenderer magicHand;
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", movement.x);;
        anim.SetFloat("Speed", movement.sqrMagnitude);
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        mãoMagia.transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1") && magicSelected == false)
            {
                if (mousePos.x < screenPoint.x)
                {
                    anim.SetTrigger("Attack_Left");
                    magicHand.flipY = true;
                }
                else if (mousePos.x > screenPoint.x)
                {
                    anim.SetTrigger("Attack_Right");
                    magicHand.flipY = false;
                }
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        if (Time.time >= nextMagicTime)
        {
            if (Input.GetButtonDown("Fire2") && canMagic == true)
            {
            Magic();
            nextMagicTime = Time.time + 1f / magicRate;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && magicSelected == true)
        {
            EquipSword();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && magicSelected == false)
        {
            EquipMagic();
        }
    }
    private void FixedUpdate()
    {
        OnWalking();
        if (Time.time >= nextDash)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Dash();
                nextDash = Time.time + 1f / dashRate;
            }
        }
    }
    void OnWalking()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public void OnAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TomarDano>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void Dash()
    {
        rb.AddForce(movement.normalized * (dashDistance * 1000));
    }
    private void Magic()
    {
        GameObject magic = Instantiate(magia, magicPoint.position, transform.rotation);
        Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();
        rb.AddForce(magicPoint.up * magicSpeed, ForceMode2D.Impulse);
    }
    private void EquipMagic()
    {
        magicIcon.SetActive(true);
        swordIcon.SetActive(false);
        canMagic = true;
        magicSelected = true;
        mãoEspada.SetActive(false);
        mãoMagia.SetActive(true);
    }
    private void EquipSword()
    {
        swordIcon.SetActive(true);
        magicIcon.SetActive(false);
        canMagic = false;
        magicSelected = false;
        mãoEspada.SetActive(true);
        mãoMagia.SetActive(false);
    }
}
