using UnityEngine;
public class Ball : MonoBehaviour
{
    private static Rigidbody2D sharedRigidbody;
    private const float speed = 5f;

    private void Awake()
    {
        if (sharedRigidbody == null)
        {
            GameObject ballController = new GameObject("BallController");
            sharedRigidbody = ballController.AddComponent<Rigidbody2D>();
            sharedRigidbody.gravityScale = 0f; 
            sharedRigidbody.velocity = new Vector2(speed, 0f);
        }
    }

    private void OnDisable()
    {
        sharedRigidbody.velocity = Vector2.zero;
    }
}