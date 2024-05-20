using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // OnTriggerEnter to collect
    // Check for Player
    // Add gems for Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            player.addDiamonds(1);
            Destroy(this.gameObject);
        }
    }
}
