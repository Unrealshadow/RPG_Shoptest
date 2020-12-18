using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI price;

    public ItemSO thisItem;
    public ShopManager thisManager;

    public GameObject buyButton;
    public GameObject sellButton;

    public PlayerInventory playerInventory;
    public void Setup(ItemSO newItem,ShopManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.itemSprite;
            price.text = thisItem.price.ToString();
        }
    }

    public void OnBuyClick()
    {
        playerInventory.playerInventoryList.Add(thisItem);
    }

    public void OnSellClick()
    {

    }
}
