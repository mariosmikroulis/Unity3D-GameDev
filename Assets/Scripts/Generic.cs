using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Generic
{
    public static Vector3 enterance {get; set;}
    public static Inventory inventory {get; set;}
    public static int difficultyLevelSet = 0;
    public static int oxygenLevel = 100;
    public static int axeTries = 0;
    public static bool hasAxe = false;
    // public static bool hasShovel = false;


    public static Inventory getInventory() {
        if(inventory == null) {
            inventory = new Inventory();
        }

        return inventory;
    }
}
