using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private float jumpHeight = 1000;
    private Rigidbody2D rigidbody2D;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Tap();
    }
    private void Tap()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                rigidbody2D.AddRelativeForce(Vector2.up * jumpHeight * Time.deltaTime);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rigidbody2D.AddRelativeForce(Vector2.up / jumpHeight * Time.deltaTime);
            }
        }
    }
}
