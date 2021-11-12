using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* This is used in order to store an item as a directory but also how much the user holds.
*/
public class InventoryItem
{
    // What is the ID?
    private string id = "";
    // What is the official name of the item?
    private string name = "";
    // Any description to use for the UI inventory?
    private string description = "";
    // What is the amount of the item that exei?
    private int amount = 0;

    // increase the amount.
    public void add(int _amount) {
        amount += _amount;
    }


    // reduce the amount
    public void remove(int _amount) {
        amount -= _amount;
    }

    // set manually the amount
    public void setAmount(int _amount) {
        amount = _amount;
    }


    // get the amount of item.
    public int getAmount() {
        return amount;
    }

    // Sets id because I was not confortable when I was setting it myself.
    public void setId(string _id) {
        id = _id;
    }

    // get the item id.
    public string getId() {
        return id;
    }

    // set the item name.
    public void setName(string _name) {
        name = _name;
    }

    // Get item name.
    public string getName() {
        return name;
    }

    // set the description of the item.
    public void setDescription(string _desc) {
        description = _desc;
    }

    // get the actual description.
    public string getDescription() {
        return description;
    }
}
