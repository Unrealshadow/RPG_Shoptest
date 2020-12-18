using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public GameObject blankShopSlot;
    public GameObject shopPanel;

    public ShopInventory shopInventory;


    private void Start()
    {
        MakeShopInventorySlots();
    }
    private void MakeShopInventorySlots()
    {
        if (shopInventory)
        {
            for (int i = 0; i < shopInventory.myShopInventory.Count; i++)
            {
                var tempSlot = Instantiate(blankShopSlot, shopPanel.transform.position, Quaternion.identity);
                tempSlot.transform.SetParent(shopPanel.transform, false);
                ShopSlot newSlot = tempSlot.GetComponent<ShopSlot>();
                if (tempSlot)
                {
                    newSlot.Setup(shopInventory.myShopInventory[i],this);
                }
            }
        }
    }


    
}
