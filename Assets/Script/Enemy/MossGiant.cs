using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _targetPosition;
    private Animator _animator;
    private void Start()
    {
        speed = 2;
        _targetPosition = pointB.position;
        _animator = GetComponentInChildren<Animator>();
    }

    public override void Attack()
    {
        
    }

    public override void Update()
    {

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

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.001f)
        {
            StartCoroutine(StopAndIdling());
            _animator.SetTrigger("Idle");

            if (_targetPosition == pointB.position)
                _targetPosition = pointA.position;
            else if (_targetPosition == pointA.position)
                _targetPosition = pointB.position;
        }
    }

    IEnumerator StopAndIdling()
    {
        while (true)
        {
            yield return new WaitForSeconds(4.5f);
        }
    }
}
