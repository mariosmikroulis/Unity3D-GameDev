using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class OxygenController : MonoBehaviour
{

    
	public Text oxygenText;
    public float timer = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        oxygenText.text = "Oxygen: 100";
    }

    void Update(){
        timer -= Time.deltaTime;
        if(timer<=0){
            int oxyLevel = int.Parse(oxygenText.text.Replace("Oxygen: ", ""))-1;
            oxygenText.text = "Oxygen: " + oxyLevel;
            timer = 10.0f;
        }
    }
}
