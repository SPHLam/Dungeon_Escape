using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MossGiant : Enemy
{
    private void Start()
    {
        Attack();
        gems = 10;
    }

    public override void Attack()
    {
        Debug.Log("Moss Giant attack!");
    }

    public override void Update()
    {
        
    }
}
