using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buyable Items List", menuName = "ScriptableObjects/Item List", order = 1)]
public class ShopInventory : ScriptableObject
{
    public List<ItemSO> myShopInventory = new List<ItemSO>();
}
