using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float speedIncreaseRate = 0.1f;
    public float maxSpeed = 10f;

    public Sprite idleSprite;
    public Animator animator;
    public AudioSource walkAudio;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private float speed;

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalScale = spriteRenderer.transform.localScale;
        speed = moveSpeed;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector2(moveX, 0).normalized;

        if (moveX != 0)
        {
            Vector3 scale = originalScale;
            scale.x *= Mathf.Sign(moveX);
            spriteRenderer.transform.localScale = scale;

            animator.enabled = true;

            if (!walkAudio.isPlaying)
                walkAudio.Play();

            float percentSpeedIncrease = (speed - moveSpeed) / (maxSpeed - moveSpeed);
            walkAudio.pitch = 1 + percentSpeedIncrease * 5f;
        }
        else
        {
            animator.enabled = false;
            spriteRenderer.sprite = idleSprite;
            walkAudio.Stop();
            walkAudio.pitch = 1f;
            speed = moveSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir.x * speed, 0);

        if (moveDir.x != 0 && speed < maxSpeed)
        {
            speed += speedIncreaseRate * Time.fixedDeltaTime;
        }
    }
}
