using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ScoreCounter sc;
    public float speed;

    public float jumpHeight = 500;
    public bool isGrounded;
    public int score;

    private Rigidbody2D rb;
    private int fallDeathYPosition = -10;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called at a fixed interval separate from framerate
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0f;

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        JumpHandler();
        FallHandler();
    }

    private void FallHandler()
    {
        if (transform.position.y <= fallDeathYPosition)
        {
            gameObject.transform.position = new Vector3(-5, -1.5f, 0);
            rb.velocity = Vector3.zero;
        }
    }

    private void JumpHandler()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            float moveHorizontal = 0f;
            float moveVertical = jumpHeight;

            Vector2 jump = new Vector2(moveHorizontal, jumpHeight);
            rb.AddForce(jump, ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    void OnCollisionExit2D()
    {
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            sc.incrementScore();
            Destroy(collision.gameObject);
        }
    }
}
