using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Camera cam;
    public SpriteRenderer player;
    public SpriteRenderer mão;
    private Animator animation;

    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (mousePos.x < screenPoint.x)
        {
            player.flipX = true;
            mão.flipY = true;
           // if (Input.GetButtonDown("Fire1"))
           // {
            //    animation.SetTrigger("1");
            //}

        }
        else
        {
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    animation.SetTrigger("2");
            //}
            player.flipX = false;
            mão.flipY = false;
        }
    }
}
