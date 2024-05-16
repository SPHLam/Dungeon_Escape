using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    // Start is called before the first frame update
    public override void Init()
    {
        speed = 1;
        base.Init();
    }

    public override void Attack()
    {
        
    }
    public void Damage(int damage)
    {

    }
}
