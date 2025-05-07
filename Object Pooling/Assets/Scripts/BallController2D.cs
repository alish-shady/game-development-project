using UnityEngine;
public class BallController2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isLaunched = false;
    private ObjectPooling pooler;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pooler = FindObjectOfType<ObjectPooling>();
    }
    void OnEnable()
    {
        isLaunched = false;
        rb.velocity = Vector2.zero;
    }
    void Update()
    {
        if (!isLaunched && Input.GetMouseButtonDown(1))
        {
            isLaunched = true;
            Vector2 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.AddForce(randomDir * 200f); 
            Invoke("TransferToSecondPool", 3f);
        }
    }
    void TransferToSecondPool()
    {
        pooler.MoveToSecondPool(gameObject);
    }
}
