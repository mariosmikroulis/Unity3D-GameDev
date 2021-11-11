using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Generic
{
    public static Vector3 enterance {get; set;}
    public static Inventory inventory {get; set;}

    public static Inventory getInventory() {
        if(inventory == null) {
            inventory = new Inventory();
        }

        return inventory;
    }
}
