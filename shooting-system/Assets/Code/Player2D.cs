using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] ushort speed = 200;
    float InputX;
    
    void Start()
    {
        if (body == null)
        {
            Debug.LogError("Rigidbody2D component is not assigned. Please assign it in the Inspector.");
            return; 
        }

        body.velocity = new Vector2(1f, 0f);
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        InputX = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(InputX * speed * Time.fixedDeltaTime, body.velocity.y);
    }
}