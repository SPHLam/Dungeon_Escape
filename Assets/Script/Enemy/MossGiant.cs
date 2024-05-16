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
        Health = health;
    }

    public override void Attack()
    {
        
    }

    public void Damage(int damage)
    {
        
    }
}
