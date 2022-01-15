using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Where are all the UIs be based on? Which parrent?
    public Transform canvas;
    private bool isOnMainScreen = false; // check if is in main screen.
    private bool isPauseMenuOn = false; // can exit from the game being paused.
    private bool forcePause = false; // forces the player to be paused.

    public Slider healthSlider;
    public Gradient healthGradient;
    private Image healthFill;

    public Slider oxygenSlider;
    public Gradient oxygenGradient;
    private Image oxygenFill;

    public Slider staminaSlider;
    public Gradient staminaGradient;
    private Image staminaFill;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    public Slider mouseSensitivitySlider;

    public static Menus instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(gameObject);
                return;
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    public static Menus getInstance() {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform statusBar = canvas.gameObject.transform.Find("StatusBar");


        // It is the main screen. They can come back to it via the pause menu.
        if (SceneManager.GetActiveScene().name == "Menu") {
            isOnMainScreen = true;
            canvas.Find("StartMenu").gameObject.SetActive(true);
            SoundManager.getInstance().stop("StrongWind");
            statusBar.gameObject.SetActive(false);
        } else {
            SoundManager.getInstance().mute("StrongWind", true);
            SoundManager.getInstance().play("StrongWind");

            statusBar.gameObject.SetActive(true);

            healthFill = healthSlider.fillRect.GetComponent<Image>();
            oxygenFill = oxygenSlider.fillRect.GetComponent<Image>();
            staminaFill = staminaSlider.fillRect.GetComponent<Image>();

            setHealthUI(1);
            setOxygenUI(1);
            setStaminaUI(1);
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
                canvas.Find("PauseMenu").gameObject.SetActive(true);
            }

            // Player wants to continue playing the game.
            else {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                canvas.Find("PauseMenu").gameObject.SetActive(false);
            }
        }
    }

    // The player wishes to go to the main screen and lose their progress.
    public void loadMainScreen() {
        Debug.Log("load");
        SceneManager.LoadScene("Menu");
    }

    // actions to do when player wins
    // gameObject.SendMessage("playerWonGame");
    public void playerWonGame() {
        forcePause = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;

        canvas.Find("WonMenu").gameObject.SetActive(true);
    }

    // actions to do when player loses
    // gameObject.SendMessage("playerLostGame");
    public void playerLostGame() {
        forcePause = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;

        canvas.Find("LostMenu").gameObject.SetActive(true);
    }

    public void openSettings() {
        canvas.Find("StartMenu").gameObject.SetActive(false);
        canvas.Find("PauseMenu").gameObject.SetActive(false);
        canvas.Find("Settings").gameObject.SetActive(true);

        masterSlider = canvas.Find("MasterVolumeSlider").GetComponent<Slider>();
        musicSlider = canvas.Find("MusicVolumeSlider").GetComponent<Slider>();
        sfxSlider = canvas.Find("SFXVolumeSlider").GetComponent<Slider>();

        masterSlider.value = SoundManager.getInstance().getMasterSoundVolume();
        musicSlider.value = SoundManager.getInstance().getMusicSoundVolume();
        sfxSlider.value = SoundManager.getInstance().getSFXSoundVolume();
        mouseSensitivitySlider.value = SoundManager.getInstance().getMasterSoundVolume();
    }

    public void closeSettings() {
        canvas.Find("Settings").gameObject.SetActive(false);

        if(SceneManager.GetActiveScene().name == "Menu") {
            canvas.Find("StartMenu").gameObject.SetActive(true);
        } else {
            canvas.Find("PauseMenu").gameObject.SetActive(true);
        }
    }

    // Load the new game story for the player to read.
    public void NewGame() {
        canvas.Find("StartMenu").gameObject.SetActive(false);
        canvas.Find("Intro01").gameObject.SetActive(true);
    }

    // go to the second text
    public void ShowStory2() {
        canvas.Find("Intro01").gameObject.SetActive(false);
        canvas.Find("Intro02").gameObject.SetActive(true);
    }

    // go to the third text
    public void ShowStory3() {
        canvas.Find("Intro02").gameObject.SetActive(false);
        canvas.Find("Intro03").gameObject.SetActive(true);
    }

    // go to the fourth text
    public void ShowStory4() {
        canvas.Find("Intro03").gameObject.SetActive(false);
        canvas.Find("Intro04").gameObject.SetActive(true);
    }

    public void setHealthUI(float amount) {
        if (healthSlider != null) {
            healthSlider.value = amount;
            healthFill.color = healthGradient.Evaluate(amount);
        }
    }

    public void setOxygenUI(float amount) {
        if(oxygenSlider != null) {
            oxygenSlider.value = amount;
            oxygenFill.color = oxygenGradient.Evaluate(amount);
        }
    }

    public void setStaminaUI(float amount) {
        if(staminaSlider != null) {
            staminaSlider.value = amount;
            staminaFill.color = staminaGradient.Evaluate(amount);
        }
    }

    public void setAnnouncementText(string str) {
        Text obj = canvas.Find("ActionText").GetComponent<Text>();

        obj.enabled = (str != "");
        canvas.Find("ActionText").gameObject.SetActive(str != "");
        obj.text = str;
    }

    public string getAnnouncementText() {
        return canvas.Find("ActionText").GetComponent<Text>().text;
    }

    // Load the Game Scene.
    public void GoToMainScene() {
        SceneManager.LoadScene("SceneOutside");
    }
}
