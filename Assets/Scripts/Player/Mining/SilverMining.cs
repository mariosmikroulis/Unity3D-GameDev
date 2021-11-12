using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverMining : Mining
{
    public string _materialName = "silver";
    public float _respawnTime = 10.0f;

    // ----------------------------------------------
    // Pickup Rates
    // ----------------------------------------------
    public float _easyPickupTime = 3.0f;
    public float _mediumPickupTime = 6.0f;
    public float _hardPickupTime = 10.0f;

    // ----------------------------------------------
    // Drop Rates
    // ----------------------------------------------
    // Easy
    public int _minDropEasy = 3;
    public int _maxDropEasy = 6;

    // Medium
    public int _minDropMedium = 2;
    public int _maxDropMedium = 4;

    // Hard level.
    public int _minDropHard = 1;
    public int _maxDropHard = 2;

    // MonoBehaviour does not support overriding variables, so I reassign them instead.
    void Start() {
        materialName = _materialName;
        respawnTime = _respawnTime;
        
        easyPickupTime = _easyPickupTime;
        mediumPickupTime = _mediumPickupTime;
        hardPickupTime = _hardPickupTime;

        minDropEasy = _minDropEasy;
        maxDropMedium = _maxDropMedium;

        minDropMedium = _minDropMedium;
        maxDropMedium = _maxDropMedium;

        minDropHard = _minDropHard;
        maxDropHard = _maxDropHard;

        Generic.getInventory().addItem("axe", 1);
    }
}
