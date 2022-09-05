using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Values")] 
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float jumpForce = 10f;
    
    private float _moveInput;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveInput * movementSpeed, rb.velocity.y);
    }
    
    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;

        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the y-force to prevent player stacking up jump momentum.
        rb.AddForce(jumpForce * transform.up, ForceMode2D.Impulse);
    }
}
