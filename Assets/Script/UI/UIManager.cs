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

    public Image selectionImage;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdatePlayerDiamondText(int diamondCount)
    {
        playerDiamondCountText.text = "Current: " + diamondCount + "G";
    }
    
    public void UpdateShopSelectionItem(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
}
