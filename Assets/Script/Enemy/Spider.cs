using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Vector3 _targetPosition;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        _animator = GetComponentInChildren<Animator>();
        _targetPosition = pointB.position;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Attack()
    {
        
    }

    public override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;

        _spriteRenderer.flipX = _isFlipped;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.001f)
        {
            _animator.SetTrigger("Idle");

            if (_targetPosition == pointA.position)
            {
                _isFlipped = false;
                _targetPosition = pointB.position;
            }
            else if (_targetPosition == pointB.position)
            {
                _isFlipped = true;
                _targetPosition = pointA.position;
            }
        }
    }
}
