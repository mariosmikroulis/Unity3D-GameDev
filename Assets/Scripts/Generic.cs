using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Generic
{
    public static Vector3 enterance {get; set;}
    // This is where the instance of inventory is stored.
    public static Inventory inventory {get; set;}
    // This is where the difficulty level is set.
    public static int difficultyLevelSet = 0;

    // this is the rate about how much oxygen the player has.
    public static int oxygenLevel = 100;

    // if hasn't got axe 2 times, 100% change to get it third time from mistery box.
    public static int axeTries = 0;
    public static bool hasAxe = false;
    // public static bool hasShovel = false;

    // Used siglinon here.
    public static Inventory getInventory() {
        if(inventory == null) {
            inventory = new Inventory();
        }

        return inventory;
    }
}
