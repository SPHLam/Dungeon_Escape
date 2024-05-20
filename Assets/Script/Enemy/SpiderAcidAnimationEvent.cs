using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAcidAnimationEvent : MonoBehaviour
{
    // Handle to the Spider
    private Spider _spider; 
    void Start()
    {
        // Assign handle to the Spider
        _spider = GameObject.Find("Spider_Enemy").GetComponent<Spider>();
    }
    public void Fire()
    {
        // Tell spider to fire acid ball
        // Use handle to call Attack() on Spider
        _spider.Attack();
    }
}
