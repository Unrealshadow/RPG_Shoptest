using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{

    public static ShopSlot Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
    }


    public Image itemImage;
    public TextMeshProUGUI price;

    public ItemSO thisItem;
    public ShopManager thisManager;

    public GameObject buyButton;
    public GameObject sellButton;
    public GameObject useButton;

    public PlayerInventory playerInventory;

    private void Start()
    {
        useButton.GetComponent<Button>().interactable = false;
        sellButton.GetComponent<Button>().interactable = false;
    }


    
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


    public void InitialCheck()
    {
        var masterList = thisManager.shopInventory.myShopInventory;
        Debug.Log(masterList.Count);
    }

    public void CheckIsAvailable()
    {
        for (int i = 0; i < playerInventory.playerInventoryList.Count; i++)
        {
            if (playerInventory.playerInventoryList.Contains(thisItem))
            {
                useButton.GetComponent<Button>().interactable = true;
                buyButton.GetComponent<Button>().interactable = false;
                sellButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void OnBuyClick()
    {
        if (playerInventory.playerInventoryList.Contains(thisItem)) {
            CheckIsAvailable();
            return;
        }
        playerInventory.playerInventoryList.Add(thisItem);
        
        thisManager.DeductMoney(thisItem.price);
        CheckIsAvailable();

    }

    public void OnSellClick()
    {
        playerInventory.playerInventoryList.Remove(thisItem);
        buyButton.GetComponent<Button>().interactable = true;
        useButton.GetComponent<Button>().interactable = false;
        thisManager.AddMoney(int.Parse(price.text.Substring(0,price.text.Length)));
        sellButton.GetComponent<Button>().interactable = false;


    }

    public void OnClickUse()
    {
        sellButton.GetComponent<Button>().interactable = false;
        useButton.GetComponent<Button>().interactable = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite = thisItem.itemSprite;
    }
}
