using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBottle : MonoBehaviour
{
    private bool used = false;
    public bool distructAfterUse = false;
    public float resetCD = 60;
    public float oxygenAmount = 10;
    private bool isInArea = false;

    // Update is called once per frame
    void Update()
    {
        if(isInArea && !used && Input.GetKey("f")) {
            Generic.addOxygen(oxygenAmount);


            if(!distructAfterUse) {
                StartCoroutine(startCD());
            } else {
                GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
                Destroy(gameObject);
            }
        }
    }

    // has our player entered our collider?
    private void OnTriggerEnter(Collider other) {
        // Is our collider a player?
        if(!other.CompareTag("Player")) {
            return;
        }
        
        isInArea = true;

        if(!used) {
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to pick & use the oxygen bottle.");
        }
    }

    // has our player exited our collider?
    private void OnTriggerExit(Collider other) {
        // Is our collider a player?
        if(!other.CompareTag("Player")) {
            return;
        }

        // hide the text and set the script that the player is out of the area
        isInArea = false;
        GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "");
    }

    // Quick thread creator to detect the reset of the pickup time.
    private IEnumerator startCD() {
        float cooldown = resetCD;
        used = true;

        while(used && !distructAfterUse) {
            cooldown -= 1;

            if(cooldown > 0 && isInArea) {
                GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "You can reuse this in " + cooldown.ToString("#") + " seconds.");
            }

            yield return new WaitForSeconds(1);
        }

        used = false;

        if(isInArea) {
            GameObject.FindGameObjectWithTag("UI").gameObject.SendMessage("setAnnouncementText", "Press [F] to pick & use the oxygen bottle.");
        }
    }
}
