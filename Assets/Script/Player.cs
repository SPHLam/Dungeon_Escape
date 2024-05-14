using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Get handle to rigid body
    private Rigidbody2D _rigidBody2D;
    private float _jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        if (_rigidBody2D == null)
        {
            Debug.LogError("Rigid body 2D is null!");
        }
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround())
        {
            Jump();
        }
    }

    private bool isOnGround()
    {
        // Raycast to detect if the Player is still on the ground or not
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.75f, 1 << 8); // Bit shift to find the layer value

        if (hitInfo.collider != null) // hit something below, aka the ground
        {
            // Debug.Log("Hit: " + hitInfo.collider.name);
            // Debug.DrawRay(transform.position, Vector2.down * 0.75f, Color.green);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Jump()
    {
        _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, _jumpForce);
    }

    private void Move()
    {
        // Horizontal input for left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Current velocity = new velocity (x, current velocity.y)
        _rigidBody2D.velocity = new Vector2(horizontalInput, _rigidBody2D.velocity.y);
    }
}
