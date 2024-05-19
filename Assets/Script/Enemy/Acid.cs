using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    // Move right at 3 meters per second
    // Detect Player hit collision and deal damage (IDamageable Interface)
    // Destroy this after at the end of the platform
    void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);

        if (transform.position.x >= -43f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IDamageable hit = collision.GetComponent<IDamageable>();

            if (hit != null)
            {
                Destroy(this.gameObject);
                hit.Damage(10);
            }
        }
    }
}
