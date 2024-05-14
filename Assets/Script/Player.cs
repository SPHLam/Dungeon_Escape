using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Get handle to rigid body
    private Rigidbody2D _rigidBody2D;
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
        // Horizontal input for left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Current velocity = new velocity (x, current velocity.y)
        _rigidBody2D.velocity = new Vector2(horizontalInput, _rigidBody2D.velocity.y);
    }
}
