using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float speed = 5f;
    private float jumpForce = 1500f;
    private float bulletSpeed = 3000f;

    [SerializeField] GameObject bulletprefab;
    [SerializeField] GameObject gunPoint;
    public Sprite[] sprites;
    private int spriteIndex;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //AnimateSprite();
    }

   

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right*speed);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //AnimateSprite();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * speed);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            //AnimateSprite();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
            Debug.Log("Jump");
        }
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletprefab, gunPoint.transform.position,gunPoint.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = (transform.forward * bulletSpeed);

        }
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex>=sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
