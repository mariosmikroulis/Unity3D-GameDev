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

    // This is used to add items into the inventory, using a List<T>
    public void addItem(string id, int amount) {
        // get the item based on the id.
        InventoryItem item = getItem(id);

        if(item == null) {
            Debug.LogError("Couldn't find " + id + " on the item list.");
            return;
        }

        item.add(amount);
    }

    // This is used to remove items into the inventory, using a List<T>
    public void removeItem(string id, int amount) {
        // get the item based on the id.
        InventoryItem item = getItem(id);

        if(item == null) {
            Debug.LogError("Couldn't find " + id + " on the item list.");
            return;
        }

        item.remove(amount);
    }

    public void setItem(string id, int amount) {
        // get the item based on the id.
        InventoryItem item = getItem(id);

        if(item == null) {
            Debug.LogError("Couldn't find " + id + " on the item list.");
            return;
        }

        item.setAmount(amount);
    }

    public InventoryItem getItem(string id) {
        // search for each item inside the item list and return the item if item.id == id.
        foreach(InventoryItem item in allItems) {
            if(item.getId() == id) {
                return item;
            }
        }

        // Couldn't find it? Then the item doesn't exist in the game at all.
        return null;
    }

    public bool hasItem(string id, int amount) {
        // get the item based on the id.
        InventoryItem item = getItem(id);

        // return if the item exists and the amount that the player holds is equal or more
        // than the required one.
        return (item != null && item.getAmount() >= amount);
    }

    // if hasn't entered amount, then just return hasItem but with both the arguments.
    public bool hasItem(string id) {
        return hasItem(id, 0);
    }

    // Get all the items inside the inventory.
    public List<InventoryItem> getItems() {
        return allItems;
    }
}
