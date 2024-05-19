using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    // Start is called before the first frame update
    public override void Init()
    {
        base.Init();
        speed = 1;
        health = 30;
        Health = health;
    }

    public override void Move()
    {

    }

    public override void Attack()
    {
        
    }

    public void Damage(int damage)
    {
        Health -= damage;
        animator.SetBool("Combat", true);
        isHit = true;

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
