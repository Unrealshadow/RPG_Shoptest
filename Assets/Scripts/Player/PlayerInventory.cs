using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Inventory List", menuName = "ScriptableObjects/Player Inventory List", order = 1)]
public class PlayerInventory : ScriptableObject
{
    public List<ItemSO> playerInventoryList = new List<ItemSO>();
}
