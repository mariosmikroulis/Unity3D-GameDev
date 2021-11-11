using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTeleportation : MonoBehaviour
{
    // teleportationId so we know where to teleport the player.
    public int teleportationId = 0;
    public bool isOnTheOutside = true;
    public Text actionText;

    private bool isOnShipPortal = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnShipPortal && Input.GetKeyUp(KeyCode.E)) {
            if(isOnTheOutside) {
                // Load the scene with the spaceship.
                Generic.enterance = GameObject.FindGameObjectWithTag("Player").transform.position;
                SceneManager.LoadScene("SampleScene");

            } else {
                // Load the outside scene and set the location on where the place is meant to be.
                SceneManager.LoadScene("SampleScene");
                
                if(Generic.enterance == null) {
                    GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("MainShip").transform.position;
                }

                else {
                    
                }
            }
        }
    }

    private bool makeGenericChecks(Collider other) {
        if(!other.CompareTag("Player")) {
            return false;
        }

        if(teleportationId == 0) {
            Debug.LogError("You haven't entered a sufficient teleportation ID, therefore, this action was not successful!");
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

        isOnShipPortal = true;
        
        actionText.text = "PRESS [E] TO EXIT THE SPACESHIP.";

        if(isOnTheOutside) {
            actionText.text = "PRESS [E] TO ENTER THE SPACESHIP";
        }

        actionText.enabled = true;

    }

    private void OnTriggerExit(Collider other) {
        if(!makeGenericChecks(other)) {
            return;
        }

        isOnShipPortal = false;
        actionText.enabled = false;
        actionText.text = "";
    }
}
