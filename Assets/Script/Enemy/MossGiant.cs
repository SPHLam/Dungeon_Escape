using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _targetPosition;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isFlipped = false;
    private void Start()
    {
        speed = 2;
        _targetPosition = pointB.position;
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Attack()
    {
        
    }

    public override void Update()
    {
        // if idle animation is playing
        // do nothing -> hint: use return
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Move();
    }

    private void Move()
    {
        // if current pos = point A
        // move to point B
        // else if current pos = point B
        // move to point A
        // ** cant use else becuz the position between 2 way points
        float step = speed * Time.deltaTime;

        _spriteRenderer.flipX = _isFlipped;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.001f)
        {
            _animator.SetTrigger("Idle");

            if (_targetPosition == pointB.position)
            {
                _isFlipped = true;
                _targetPosition = pointA.position;
            }
                
            else if (_targetPosition == pointA.position)
            {
                _isFlipped = false;
                _targetPosition = pointB.position;
            }
        }
    }
}
