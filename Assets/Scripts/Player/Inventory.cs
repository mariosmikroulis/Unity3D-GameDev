using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // This is the list of all the itemstems of the game.
    private static List<InventoryItem> allItems;

    void Start() {
        // get started with the variables.
        allItems = new List<InventoryItem>();

        // Register all allItems here.
        allItems.Add(createItem("gold", "Gold", "This gold is a material to be used for something."));
    }

    private InventoryItem createItem(string id, string name, string description) {
        // create the inventory item object.
        InventoryItem item = new InventoryItem();

        // set the necessary fields;
        item.setId(id);
        item.setName(name);
        item.setDescription(description);
        
        // return the object.
        return item;
    }

    public void addItem(string id, int amount) {
        // get the item based on the id.
        InventoryItem item = getItem(id);

        if(item == null) {
            Debug.LogError("Couldn't find " + id + " on the item list.");
            return;
        }

        item.add(amount);
    }

    public void removeItem(string id, int amount) {
        InventoryItem item = getItem(id);

        if(item == null) {
            Debug.LogError("Couldn't find " + id + " on the item list.");
            return;
        }

        item.remove(amount);
    }

    public void setItem(string id, int amount) {
        InventoryItem item = getItem(id);

        if(item == null) {
            Debug.LogError("Couldn't find " + id + " on the item list.");
            return;
        }

        item.setAmount(amount);
    }

    public InventoryItem getItem(string id) {
        foreach(InventoryItem item in allItems) {
            if(item.getId() == id) {
                return item;
            }
        }

        return null;
    }

    public bool hasItem(string id, int amount) {
        InventoryItem item = getItem(id);

        return (item != null && item.getAmount() >= amount);
    }

    public bool hasItem(string id) {
        return hasItem(id, 0);
    }

    public List<InventoryItem> getItems() {
        return allItems;
    }
}
