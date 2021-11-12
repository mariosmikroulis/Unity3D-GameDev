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
    public static bool hasAxe = true;
    public static bool hasChip = true;
    public static int fuel = 20;
    public static bool hasPump = true;
    public static int gold = 20;
    public static int silver = 20;
    public static bool fuelCompleted = false;
    public static bool chipCompleted = false;
    public static bool pumpCompleted = false;
    public static bool goldCompleted = false;
    public static bool silverCompleted = false;
    public static int tasksCompleted = 0;
    // public static bool hasShovel = false;


    public static Inventory getInventory() {
        if(inventory == null) {
            inventory = new Inventory();
        }

        return inventory;
    }
}
