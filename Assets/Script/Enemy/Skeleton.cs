using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        speed = 1;
    }

    public override void Attack()
    {
        
    }
    public void Damage(int damage)
    {

    }
}
