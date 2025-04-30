using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BlobMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    public SpriteRenderer headSprite; 
    public SpriteRenderer bodySprite;
    private Vector3 originalScale;

    void Start()
    {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    originalScale = transform.localScale;
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float moveSpeed = isRunning ? runSpeed : walkSpeed;
        float animSpeed = isRunning ? 1.5f : 1.25f;

        transform.Translate(new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f));

        if (moveInput != 0)
        {
        
         bool flip = moveInput < 0;
            headSprite.flipX = flip;
            bodySprite.flipX = flip;
        }
        animator.SetFloat("Speed", Mathf.Abs(moveInput) * animSpeed);
    }
}
