using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public GameObject blankShopSlot;
    public GameObject contentPanel;
    public GameObject mainShopPanel;
    public ShopInventory shopInventory;
    public TextMeshProUGUI money;
    private void Start()
    {
        MakeShopInventorySlots();
        blankShopSlot.GetComponent<ShopSlot>().CheckIsAvailable();
    }
    private void MakeShopInventorySlots()
    {
        if (shopInventory)
        {
            for (int i = 0; i < shopInventory.myShopInventory.Count; i++)
            {
                var tempSlot = Instantiate(blankShopSlot, contentPanel.transform.position, Quaternion.identity);
                tempSlot.transform.SetParent(contentPanel.transform, false);
                ShopSlot newSlot = tempSlot.GetComponent<ShopSlot>();
                if (tempSlot)
                {
                    newSlot.Setup(shopInventory.myShopInventory[i],this);
                }
            }
            ShopSlot.Singleton.InitialCheck();
        }
    }

    public void OnClickClose()
    {
        
        if(mainShopPanel.activeSelf == true)
        {
            mainShopPanel.SetActive(false);
        }
            
    }

    public void DeductMoney(int price)
    {
        
        var tempPrice = int.Parse( money.text.Substring(0, money.text.Length-1));
        if(tempPrice > 0)
        {
            var currentAmount = tempPrice - price;
            money.text = currentAmount.ToString() + "$";
        }
    }
    public void AddMoney(int price)
    {

        var tempPrice = int.Parse(money.text.Substring(0, money.text.Length - 1));
        var currentAmount = tempPrice + price;
        money.text = currentAmount.ToString() + "$";
    }
}
