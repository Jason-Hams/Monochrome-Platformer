using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 velocity;

    private Vector2 moveDirection;
    private bool levelComplete;
    private bool isGrounded;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite whiteCat;
    [SerializeField] private Sprite blackWolf;
    private bool isBlackWolf;

    private void Update()
    {
        MovePlayer();
        Jump();

    }

    private void MovePlayer()
    {
        if(levelComplete == false)
        {
            moveDirection.x = Input.GetAxisRaw("Horizontal");

            rigidbod.transform.Translate(Vector2.right * moveDirection.x * Time.deltaTime * speed);
            spriteRenderer.flipX = moveDirection.x < 0f;
        }
       
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && levelComplete == false)
        {
            rigidbod.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            ChangeSprite();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("ground");
        }
    }

    private void ChangeSprite()
    {
        if (isBlackWolf == false)
        {
            spriteRenderer.sprite = blackWolf;
            gameObject.layer = 7;
            isBlackWolf = true;
        }
        else if (isBlackWolf == true)
        {
            spriteRenderer.sprite = whiteCat;
            gameObject.layer = 6;
            isBlackWolf = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            GameManager.singelton.LevelComplete();
            levelComplete = true;
        }
    }
}
