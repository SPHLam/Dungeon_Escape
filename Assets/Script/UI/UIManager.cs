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
    public Text playerHUDGemCountText;
    public Image[] healthBarsHUD;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdatePlayerDiamondText(int diamondCount)
    {
        playerDiamondCountText.text = "Current: " + diamondCount + "G";
    }

    public void UpdateHUDDiamondText(int diamondCount)
    {
        playerHUDGemCountText.text = "" + diamondCount;
    }
    
    public void UpdateShopSelectionItem(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateHUDLives(int livesRemaining)
    {
        for (int i = 0; i < healthBarsHUD.Length; i++)
        {
            if (i < livesRemaining)
            {
                healthBarsHUD[i].enabled = true;
            }
            else
            {
                healthBarsHUD[i].enabled = false;
            }
        }
    }
}
