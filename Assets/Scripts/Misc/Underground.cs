using UnityEngine;

public class Underground : MonoBehaviour {

	// If player falls off map he dies
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Menus.getInstance().playerLostGame();
        }
    }
}
