using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName ="Buyable Item",menuName ="ScriptableObjects/ItemSO",order =1)]
public class ItemSO : ScriptableObject
{
    public Sprite itemSprite;
    public int price;
    public bool isBought;
    public bool isUsing;
}
