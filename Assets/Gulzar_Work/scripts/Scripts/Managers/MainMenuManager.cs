using UnityEngine;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    public Text mainMenucoinText;
    public GameObject ExitPanel;
    public GameObject Char;
    public Camera cam;
    public GameObject Will_Add_Soon_Panel;

    // Use this for initialization
    private void OnEnable()
    {
        cam.gameObject.SetActive(true);
        Canvas canvas = GameObject.FindGameObjectWithTag("Can").GetComponent<Canvas>();
       // cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cam;
        }
        Char = GameObject.FindGameObjectWithTag("MainMenu_Char");
        mainMenucoinText.text = PlayerData.Coins.ToString();
    }
    public void MoreGames()
    {
        // Application.OpenURL("");
        Will_Add_Soon_Panel.SetActive(true);
    }
    public void RateUS()
    {
        // Application.OpenURL("market://details?id=");
        Will_Add_Soon_Panel.SetActive(true);
    }

    public void PrivacyPolicy()
    {
        //Application.OpenURL("");
        Will_Add_Soon_Panel.SetActive(true);
    }

    public void NoBtnClicked()
    {
        ExitPanel.SetActive(false);
        Char.SetActive(true);
    }

    public void ExitBtnClicked()
    {
        ExitPanel.SetActive(true);
        Char.SetActive(false);
    }

    public void YesBtnClicked()
    {
        ExitPanel.SetActive(false);
        Char.SetActive(true);
        Application.Quit();
    }
}  

   