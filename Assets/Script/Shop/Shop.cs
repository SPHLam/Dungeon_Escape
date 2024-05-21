using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public UIManager uiManager;

    private int _itemIndex = 0;
    private int _itemPrice = 0;

    private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is null in Shop.cs");
        }
    }

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

        switch(itemIndex)
        {
            case 1:
                _itemIndex = 1;
                _itemPrice = 400;
                uiManager.UpdateShopSelectionItem(-30);
                break;
            case 2:
                _itemIndex = 2;
                _itemPrice = 100;
                uiManager.UpdateShopSelectionItem(-130);
                break;
            default:
                _itemIndex = 0;
                _itemPrice = 240;
                uiManager.UpdateShopSelectionItem(70);
                break;
        }
    }

    public void BuyItem()
    {
        if (_player.getDiamonds() >= _itemPrice)
        {
            if (_itemIndex == 2)
            {
                GameManager.Instance.hasKeyCastle = true;
            }
            _player.subtractDiamonds(_itemPrice);
            uiManager.UpdatePlayerDiamondText(_player.getDiamonds());
            uiManager.UpdateHUDDiamondText(_player.getDiamonds());
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }
}
