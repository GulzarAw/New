using UnityEngine;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    public Text mainMenucoinText;
    public GameObject ExitPanel;
    public GameObject Char;
    public Camera cam;

    // Use this for initialization
    private void OnEnable()
    {
        //Canvas canvas = GameObject.FindGameObjectWithTag("Can").GetComponent<Canvas>();
        //cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //if (canvas != null)
        //{
        //    canvas.renderMode = RenderMode.WorldSpace;
        //    canvas.worldCamera = cam;
        //}
        Char = GameObject.FindGameObjectWithTag("MainMenu_Char");
    }
    public void MoreGames()
    {
       // Application.OpenURL("");
    }
    public void RateUS()
    {
       // Application.OpenURL("");
    }

    public void PrivacyPolicy()
    {
        //Application.OpenURL("");
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