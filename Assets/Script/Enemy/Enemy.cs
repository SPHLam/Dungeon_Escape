using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;
    public Transform pointA, pointB;
    protected bool isFlipped;

    protected Vector3 targetPosition;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    public virtual void Init()
    {
        targetPosition = pointB.position;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Move()
    {
        // if current pos = point A
        // move to point B
        // else if current pos = point B
        // move to point A
        // ** cant use else becuz the position between 2 way points

        float step = speed * Time.deltaTime;

        spriteRenderer.flipX = isFlipped; // Model animation flip side

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            animator.SetTrigger("Idle");

            if (targetPosition == pointB.position)
            {
                isFlipped = true; // Flip the animation for route reverse
                targetPosition = pointA.position;
            }

            else if (targetPosition == pointA.position)
            {
                isFlipped = false;
                targetPosition = pointB.position;
            }
        }
    }
    public abstract void Attack();

    public virtual void Start()
    {
        Init();
    }

    public virtual void Update()
    {        
        // if idle animation is playing
        // do nothing -> hint: use return
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Move();
    }
}
