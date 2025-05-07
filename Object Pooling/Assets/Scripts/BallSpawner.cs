using UnityEngine;
public class BallSpawner : MonoBehaviour
{
    public ObjectPooling objectPooling; 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBall();
        }
    }
    void SpawnBall()
    {
        GameObject ball = objectPooling.GetBallFromPool();

        if (ball != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ball.transform.position = new Vector2(mousePos.x, mousePos.y);
        }
    }
}
