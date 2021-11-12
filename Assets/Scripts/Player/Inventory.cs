using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // This is the list of all the itemstems of the game.
    private List<InventoryItem> allItems;

    public Inventory() {
        // get started with the variables.
        allItems = new List<InventoryItem>();

        // Register all allItems here.
        allItems.Add(createItem("unknown", "Unknown Item", "If you see this item, then something goes wrong."));

        allItems.Add(createItem("gold", "Gold", "This gold is a material to be used for something."));
        allItems.Add(createItem("silver", "Silver", "This silver is a material to be used for something."));
        allItems.Add(createItem("stone", "Stone", "This stone is a material to be used for something."));
        allItems.Add(createItem("axe", "Axe Pickup", "The axe is used for mining."));
        allItems.Add(createItem("shovel", "Shovel", "The shovel is used for looking for rare materials."));
        allItems.Add(createItem("torch", "Torch", "This is used to make your area brighter."));
        allItems.Add(createItem("fuel", "Fuel", "Energy for your ship."));
        allItems.Add(createItem("pump", "Pump", "Used to pump the fuel to the combustion chamber."));
        allItems.Add(createItem("chip", "Chip", "Controls the electronics of your ship."));
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
