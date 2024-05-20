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
        gems = 5;
        speed = 2;
        health = 50;
        Health = health;
    }

    public override void Attack()
    {
        
    }

    public void Damage(int damage)
    {
        if (isDead == true)
            return;

        Health -= damage;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("Combat", true);

        if (Health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
            SpawnDiamonds();
        }
    }

    private void SpawnDiamonds()
    {
        Instantiate(diamondPrefab, transform.position, Quaternion.identity);
        Instantiate(diamondPrefab, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
        Instantiate(diamondPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        Instantiate(diamondPrefab, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
        Instantiate(diamondPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
    }
}
