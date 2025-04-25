using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2d : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;

        // Flip sprite based on direction
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        // Send movement speed to the animator
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }
}
