using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Where are all the UIs be based on? Which parrent?
    public Transform canvas;
    private bool isOnMainScreen = false; // check if is in main screen.
    private bool isPauseMenuOn = false; // can exit from the game being paused.
    private bool forcePause = false; // forces the player to be paused.
    
    // Start is called before the first frame update
    void Start()
    {
        // It is the main screen. They can come back to it via the pause menu.
        if(SceneManager.GetActiveScene().name == "Menu") {
            isOnMainScreen = true;
            canvas.gameObject.transform.Find("StartMenu").gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnMainScreen && !forcePause && Input.GetKeyUp(KeyCode.Escape)) {
            isPauseMenuOn = !isPauseMenuOn;
            
            // Player wants to pause the game.
            if(isPauseMenuOn) {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                canvas.gameObject.transform.Find("PauseMenu").gameObject.SetActive(true);
            }

            // Player wants to continue playing the game.
            else {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                canvas.gameObject.transform.Find("PauseMenu").gameObject.SetActive(false);
            }
        }
    }

    // The player wishes to go to the main screen and lose their progress.
    public void loadMainScreen() {
        SceneManager.LoadScene("Menu");
    }

    // actions to do when player wins
    // gameObject.SendMessage("playerWonGame");
    public void playerWonGame() {
        forcePause = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;

        canvas.gameObject.transform.Find("WonMenu").gameObject.SetActive(true);
    }

    // actions to do when player loses
    // gameObject.SendMessage("playerLostGame");
    public void playerLostGame() {
        forcePause = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;

        canvas.gameObject.transform.Find("LostMenu").gameObject.SetActive(true);
    }

    // Load the new game story for the player to read.
    public void NewGame() {
        canvas.gameObject.transform.Find("StartMenu").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro01").gameObject.SetActive(true);

    }

    // go to the second text
    public void ShowStory2() {
        canvas.gameObject.transform.Find("Intro01").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro02").gameObject.SetActive(true);
    }

    // go to the third text
    public void ShowStory3() {
        canvas.gameObject.transform.Find("Intro02").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro03").gameObject.SetActive(true);
    }

    // go to the fourth text
    public void ShowStory4() {
        canvas.gameObject.transform.Find("Intro03").gameObject.SetActive(false);
        canvas.gameObject.transform.Find("Intro04").gameObject.SetActive(true);
    }

    // Load the Game Scene.
    public void GoToMainScene() {
        canvas.gameObject.transform.Find("Intro04").gameObject.SetActive(false); 
        SceneManager.LoadScene("SceneOutside");
    }
}
