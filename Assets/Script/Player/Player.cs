using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    // Get handle to rigid body
    private Rigidbody2D _rigidBody2D;
    private float _speed = 7.75f;
    private float _jumpForce = 7.5f;
    private int _diamond = 1000;
    private PlayerAnimation _playerAnimation;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        if (_rigidBody2D == null)
        {
            Debug.LogError("Rigid body 2D is null!");
        }

        _playerAnimation = GetComponent<PlayerAnimation>();

        Health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Diamond: " + _diamond);
        Move();

        if (isOnGround())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
    }

    private bool isOnGround()
    {
        // Raycast to detect if the Player is still on the ground or not
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.75f, 1 << 8); // Bit shift to find the layer value

        if (hitInfo.collider != null) // hit something below, aka the ground
        {
            Debug.DrawRay(transform.position, Vector2.down * 0.75f, Color.green);
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator WaitUntilHitTheGround()
    {
        yield return new WaitForSeconds(1.5f);
        _playerAnimation.Jump(false);
    }

    private void Jump()
    {
        _playerAnimation.Jump(true);
        _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, _jumpForce);
        StartCoroutine(WaitUntilHitTheGround());
    }

    private void Attack()
    {
        _playerAnimation.Attack();
    }

    private void Move()
    {
        // Horizontal input for left/right
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calling PlayerAnimation script to update animation from idle to run
        _playerAnimation.Run(horizontalInput);
        _playerAnimation.Flip(horizontalInput);

        // Current velocity = new velocity (x, current velocity.y)
        _rigidBody2D.velocity = new Vector2(horizontalInput * _speed, _rigidBody2D.velocity.y);
    }

    public void Damage(int damage)
    {
        Health -= damage;
        
        if (Health <= 0)
        {
            _playerAnimation.Death();
        }
    }

    public void addDiamonds(int numsOfDiamond)
    {
        _diamond += numsOfDiamond;
    }

    public int getDiamonds()
    {
        return _diamond;
    }

    public void subtractDiamonds(int numsOfDiamond)
    {
        _diamond -= numsOfDiamond;
    }
}
