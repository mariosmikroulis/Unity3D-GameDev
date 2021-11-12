using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public int storyId = 0;

    public Transform canvas;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Menu") {
            canvas.gameObject.transform.Find("StartMenu").gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame() {
        canvas.gameObject.transform.Find("StartMenu").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro01").gameObject.SetActive(true);

    }

    public void ShowStory2() {
        canvas.gameObject.transform.Find("Intro01").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro02").gameObject.SetActive(true);
    }

    public void ShowStory3() {
        canvas.gameObject.transform.Find("Intro02").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro03").gameObject.SetActive(true);
    }

    public void ShowStory4() {
        canvas.gameObject.transform.Find("Intro03").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro04").gameObject.SetActive(true);
    }

    
    public void GoToMainScene() {
        canvas.gameObject.transform.Find("Intro04").gameObject.SetActive(false); 
        Debug.Log("Run Main Scene");
    }
}
