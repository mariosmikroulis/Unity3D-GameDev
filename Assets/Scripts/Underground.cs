using UnityEngine;

public class Underground : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Menus.getInstance().playerLostGame();
        }
    }
}
