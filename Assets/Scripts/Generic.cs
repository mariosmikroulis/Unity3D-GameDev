using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public static class Generic
{
    public static Vector3 enterance {get; set;}
    public static Inventory inventory {get; set;}
    public static int difficultyLevelSet = 0;

    // Status
    public static float oxygenLevel = 100;
    public static float maxOxygen = 100;

    public static float curHealth = 1000;
    public static float maxHealth = 1000;

    public static float stamina = 100;

    public static int axeTries = 0;
    public static bool hasAxe = false;
    public static bool hasChip = false;
    public static int fuel = 0;
    public static bool hasPump = false;
    public static int gold = 0;
    public static int silver = 0;
    public static bool fuelCompleted = false;
    public static bool chipCompleted = false;
    public static bool pumpCompleted = false;
    public static bool goldCompleted = false;
    public static bool silverCompleted = false;
    public static int tasksCompleted = 0;

    public static LocationArea locationArea = LocationArea.MainShip;
    // public static bool hasShovel = false;


    public static Inventory getInventory() {
        if(inventory == null) {
            inventory = new Inventory();
        }

        return inventory;
    }

    public static float getMaxHealth() {
        return maxHealth;
    }

    public static float setMaxHealth(float amount) {
        float old = maxHealth;
        maxHealth = amount;

        GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setHealthUI", curHealth/maxHealth);

        return old;
    }

    public static float getHealth() {
        return curHealth;
    }

    public static float setHealth(float amount) {
        float old = curHealth;

        if(amount < 0) {
            amount = 0;
        } else if(amount > maxHealth) {
            amount = curHealth;
        }

        curHealth = amount;

        GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setHealthUI", curHealth/maxHealth);

        return old;
    }

    public static float addHealth(float amount) {
        if(amount < 0) {
            amount *= -1;
        }

        return setHealth(curHealth + amount);
    }

    public static float removeHealth(float amount) {
        if(amount < 0) {
            amount *= -1;
        }

        return setHealth(curHealth - amount);
    }

    public static float getOxygen() {
        return oxygenLevel;
    }

    public static float setOxygen(float amount) {
        float old = oxygenLevel;
        oxygenLevel = amount;

        if(oxygenLevel > maxOxygen) {
            oxygenLevel = maxOxygen;
        } else if(oxygenLevel < 0) {
            oxygenLevel = 0;
        }
        
        GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setOxygenUI", oxygenLevel/100);
        return oxygenLevel;
    }


    public static float addOxygen(float amount) {
        if(amount < 0) {
            amount *= -1;
        }

        return setOxygen(oxygenLevel + amount);
    }


    public static float reduceOxygen(float amount) {
        if(amount < 0) {
            amount *= -1;
        }

        return setOxygen(oxygenLevel - amount);
    }

    public static float getStamina()
    {
        return stamina;
    }

    public static float setStamina(float amount)
    {
        float old = stamina;
        stamina = amount;

        if (stamina > 100)
        {
            stamina = 100;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }

        GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setStaminaUI", stamina / 100);
        return stamina;
    }

    public static float addStamina(float amount)
    {
        if (amount < 0)
        {
            amount *= -1;
        }

        return setStamina(stamina + amount);
    }

    public static float removeStamina(float amount)
    {
        if (amount < 0)
        {
            amount *= -1;
        }

        return setStamina(stamina - amount);
    }

    public static LocationArea getLocationArea() {
        return locationArea;
    }

    public static LocationArea setLocationArea(LocationArea area) {
        LocationArea old = locationArea;
        locationArea = area;

        SoundManager.getInstance().mute("StrongWind", (area != LocationArea.World));

        return old;
    }
}
