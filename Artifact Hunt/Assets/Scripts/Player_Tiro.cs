using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tiro : MonoBehaviour
{
    public Camera cam;
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        lookDirection = cam.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }
}
