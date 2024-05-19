using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acid;
    public int Health { get; set; }

    // Start is called before the first frame update
    public override void Init()
    {
        base.Init();
        speed = 1;
        health = 10;
        Health = health;
    }

    public override void Move()
    {

    }

    public override void Attack()
    {
        // Instantiate the Acid
        Instantiate(acid, transform.position, Quaternion.identity);
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
