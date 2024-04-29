using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GamaManager : MonoBehaviour
{
    public static GamaManager Inst;
    public GameObject PausePanel;
    public GameObject[] Levels;
    public float Delay_LevelComplete = 1f, Delay_LevelFail = 1f;
    public static bool LevelCompletFlag = false, LevelFailFlag = false;
    public Text level;
    public int currentLevel;
    public Text level_no;
    public Camera cam;

    void Start()
    {
        Inst = this;
        currentLevel = PlayerData.SelectedLevelID;
        All_Levels_Off();
        Levels[currentLevel].SetActive(true);
    }
    private void OnEnable()
    {
        Canvas canvas = GameObject.FindGameObjectWithTag("Can").GetComponent<Canvas>();
       // cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //    canvas.worldCamera = cam;
        }
    }

    void Update()
    {
         RenderSettings.skybox.SetFloat("_Rotation", Time.time * 3.4f);
    }
    public void AllButtonHandler_Function(string ButtonName)
    {
        Debug.Log("i am pause");
        if (ButtonName == "pause")
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
        else if (ButtonName == "resume")
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
        else if (ButtonName == "restart")
        {
            Time.timeScale = 1;
            //   AudioManager.instance.Play("BtnClick");
            SceneManager.LoadScene(1);
        }
        else if (ButtonName == "Comprestart")
        {
            Time.timeScale = 1;
            //LoadingPanel.SetActive(true);
         //   Application.LoadLevel("GamePlay");
            PlayerPrefs.SetInt("Currentlevel", PlayerPrefs.GetInt("Currentlevel") - 1);
        }
        else if (ButtonName == "home")
        {
            Time.timeScale = 1;
          //  AudioManager.instance.Play("BtnClick");
            SceneManager.LoadScene(0);
        }
        else if (ButtonName == "next")
        {
            PlayerData.Coins += 100;

                Time.timeScale = 1f;
                //    AudioManager.instance.Play("BtnClick");
                if (currentLevel + 1 >= 10)
                {
                Debug.LogError(PlayerData.TotalLevelUnlocked());
                SceneManager.LoadScene(3);
                }
                else if (currentLevel + 1 >= PlayerData.TotalLevelUnlocked())
                {
                Debug.LogError(PlayerData.TotalLevelUnlocked());
                    currentLevel++;
                    PlayerData.SelectedLevelID = currentLevel;
                    PlayerPrefs.SetInt("LevelsUnlocked", currentLevel + 1);
               // PlayerData.Total_Levels_Unlocked += currentLevel + 1;
                    PlayerPrefs.Save();
                    SceneManager.LoadScene(3);
                }
                else
                {
                Debug.LogError(PlayerData.TotalLevelUnlocked()+ "000");
                currentLevel++;
                    PlayerData.SelectedLevelID = currentLevel;
                    SceneManager.LoadScene(3);
                }
        }
    }
    public void skipLevel()
    {
        if (PlayerPrefs.GetInt("Level") == PlayerPrefs.GetInt("Currentlevel") + 1 && PlayerPrefs.GetInt("Level") < 20)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        }
        PlayerPrefs.SetInt("Currentlevel", PlayerPrefs.GetInt("Currentlevel") + 1);
            Time.timeScale = 1;
           // LoadingPanel.SetActive(true);
//            Application.LoadLevel("GamePlay");
    }
    public void All_Levels_Off()
    {
        for(int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }
    }
  
}  

   