using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int itemID;
    public string itemName;
    [TextArea] public string itemDescription;
    public Sprite itemIcon;
    public Dictionary<string, int> itemStats = new Dictionary<string, int>();
    public Item(int itemID, string itemName, string itemDescription, Dictionary<string, int> stats) {
        this.itemID = itemID;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemIcon = Resources.Load<Sprite>("Sprites" + itemName);

    }

    public Item(Item item) {
        this.itemID = item.itemID;
        this.itemName = item.itemName;
        this.itemDescription = item.itemDescription;
        this.itemIcon = item.itemIcon;
        this.itemStats = item.itemStats;
    }
}
