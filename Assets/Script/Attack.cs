using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _hasBeenHit;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable targetHit = collision.GetComponent<IDamageable>();

        if (targetHit != null && !_hasBeenHit) // Hit something with an IDamageable interface
        {
            Debug.Log("Hit: " + collision.name);
            targetHit.Damage(10);
            _hasBeenHit = true;
            StartCoroutine(AttackCoolDown());
        }
    }

    IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(1.0f);
        _hasBeenHit = false;
    }
}
