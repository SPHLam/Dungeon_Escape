using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public UIManager uiManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            int playerDiamondCount = player.getDiamonds();

            if (player != null)
            {
                uiManager.UpdatePlayerDiamondText(playerDiamondCount);
            }

            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int itemIndex)
    {
        // 0 - flame sword, 1 - boots of flight, 2 - key to castle
        Debug.Log("SelectItem(): " + itemIndex);

        switch(itemIndex)
        {
            case 0:
                uiManager.UpdateShopSelectionItem(70);
                break;
            case 1:
                uiManager.UpdateShopSelectionItem(-30);
                break;
            case 2:
                uiManager.UpdateShopSelectionItem(-130);
                break;
        }
    }
}
