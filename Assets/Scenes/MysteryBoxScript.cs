using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MysteryBoxScript : MonoBehaviour
{
	public Text announcementsText;
    void OnTriggerEnter(){
    	announcementsText.text = "Press F to open the box";
    }
    void OnTriggerExit(){
    	announcementsText.text = "";
    }
}
