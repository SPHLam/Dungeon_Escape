using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance = null)
            {
                Debug.LogError("UI Manager is null!");
            }

            return _instance;
        }
    }

    public Text playerDiamondCountText;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdatePlayerDiamondText(int diamondCount)
    {
        playerDiamondCountText.text = "Current: " + diamondCount + "G";
    }
    
    public void Test()
    {
        Debug.Log("Im stupid"!);
    }
}
