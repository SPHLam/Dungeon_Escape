using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;
    public Transform pointA, pointB;
    protected bool isFlipped; // Flip the sprite when reversing the route
    protected bool isHit; // Hit
    protected bool isDead;

    protected Vector3 targetPosition;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected Player player;

    public virtual void Init()
    {
        targetPosition = pointB.position;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            Vector3 direction = player.transform.position - transform.position;

            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        BackToIdleFromCombat();

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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && animator.GetBool("Combat") == false)
        {
            return;
        }
        else if (isDead == true)
        {
            return;
        }

        Move();
    }
    public virtual void BackToIdleFromCombat()
    {
        if (Vector3.Distance(player.transform.position, transform.position) >= 2f)
        {
            isHit = false;
            animator.SetBool("Combat", false);
        }
    }
}
