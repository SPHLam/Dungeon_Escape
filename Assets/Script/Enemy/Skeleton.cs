using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        gems = 4;
        speed = 1;
        health = 40;
        Health = health;
    }

    public override void Attack()
    {
        
    }
    public void Damage(int damage)
    {
        Health -= damage;
        isHit = true;

        animator.SetTrigger("Hit");
        animator.SetBool("Combat", true);

        if (Health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }
}