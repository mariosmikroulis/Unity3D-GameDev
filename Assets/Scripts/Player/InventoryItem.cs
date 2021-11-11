using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    private string id = "";
    private string name = "";
    private string description = "";
    private int amount = 0;

    public void add(int _amount) {
        amount += _amount;
    }

    public void remove(int _amount) {
        amount -= _amount;
    }

    public void setAmount(int _amount) {
        amount = _amount;
    }

    public int getAmount() {
        return amount;
    }

    public void setId(string _id) {
        id = _id;
    }

    public string getId() {
        return id;
    }

    public void setName(string _name) {
        name = _name;
    }

    public string getName() {
        return name;
    }

    public void setDescription(string _desc) {
        description = _desc;
    }

    public string getDescription() {
        return description;
    }
}
