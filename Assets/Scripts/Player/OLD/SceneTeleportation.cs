using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTeleportation : MonoBehaviour
{
    // teleportationId so we know where to teleport the player.
    public int teleportationId = 0;
    public bool isOutside = false;
    public Text actionText;
    private bool isOnAnyPortal = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Is player on any portal environment and pressed F?
        if(isOnAnyPortal && Input.GetKeyUp(KeyCode.F)) {
            // Get the current player location and store it temporarily.
            Vector3 tempLoc = GameObject.FindGameObjectWithTag("Player").transform.position;


            // if the player has teleported again, then use the teleport loc, where he was firstly teleported.
            if(Generic.enterance != null) {
                GameObject.FindGameObjectWithTag("Player").transform.position = Generic.enterance;
            }


            // probably it is a new game. Just get the coordinates of the main ship, where the player supposed to spawn.
            else {
                GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("MainShip").transform.Find("DoorArea").transform.position;
            }

            // store the player location
            Generic.enterance = tempLoc;

            // just change it from false to true or vice versa (contrudiction).
            isOutside = !isOutside;
        }
    }

    // Checking things like 
    private bool makeGenericChecks(Collider other) {
        if(!other.CompareTag("Player")) {
            return false;
        }

        if(actionText == null) {
            Debug.LogError("You haven't defined the necessary UI Text child to get this working!");
            return false;
        }

        return true;
    }


    private void OnTriggerEnter(Collider other) {
        if(!makeGenericChecks(other)) {
            return;
        }

        isOnAnyPortal = true;
        
        actionText.text = "PRESS [E] TO EXIT THE SPACESHIP.";

        if(isOutside) {
            actionText.text = "PRESS [E] TO ENTER THE SPACESHIP";
        }

        actionText.enabled = true;

    }

    private void OnTriggerExit(Collider other) {
        if(!makeGenericChecks(other)) {
            return;
        }

        isOnAnyPortal = false;
        actionText.enabled = false;
        actionText.text = "";
    }
}
