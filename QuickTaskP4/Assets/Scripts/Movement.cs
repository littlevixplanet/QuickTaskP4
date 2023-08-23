using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    public bool gameOver = false;
    public bool isOnGround = true;
    private Rigidbody2D playerRb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRb.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
                isOnGround = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
        if (collision.gameObject.CompareTag("Win"))
        {
            gameOver = true;
            Debug.Log("You Win");
        }
        if (collision.gameObject.CompareTag("Lose"))
        {
            gameOver = true;
            Debug.Log("You Lose");
        }
    }
}
