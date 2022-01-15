using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGround : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("player")) {
            Menus.getInstance().playerLostGame();
        }
    }
}
