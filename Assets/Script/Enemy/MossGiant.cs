using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        speed = 2;
        health = 50;
        Health = health;
    }

    public override void Attack()
    {
        
    }

    public void Damage(int damage)
    {
        Health -= damage;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("Combat", true);

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
