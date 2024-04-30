using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelSelectionManager : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject[] lockImages;
    public GameObject[] selectImages;
    public Button nextBtn;
    public GameObject modeSelectionPanel;
    public GameObject Content;
    public GameObject coinBG;
    public Text coinText;
    public Material Unlocked_Material;
    public GameObject[] Panels;

    private void OnEnable()
    {
        // coinBG.GetComponent<DOTweenAnimation>().DORestart();
        //  coinText.text = PlayerData.Coins.ToString();
        PlayerData.Total_Levels_Unlocked = PlayerPrefs.GetInt("LevelsUnlocked",1);
        if (ShareValues.mode_no == 0)
        {
            All_Panel_Off();
          
            for (int i = 0; i < levelButtons.Length; i++)
            {
               
                if (i < PlayerData.TotalLevelUnlocked())
                {
                    levelButtons[i].interactable = true;
                    lockImages[i].gameObject.SetActive(false);
                    //lockImages[i].text = "Played";
                }
                else
                {
                    levelButtons[i].interactable = false;
                    //lockImages[i].text = "Play";
                   // levelButtons[i].gameObject.GetComponent<Image>().material = null;
                    lockImages[i].gameObject.SetActive(true);
                }
            }
            UnselectLevelBtn();
           // levelButtons[PlayerData.TotalLevelUnlocked() -1 ].gameObject.GetComponent<Image>().material = Unlocked_Material;
        }
    }

    public void LevelBtnClicked(int levelNum)
    {
        UnselectLevelBtn();
        if(ShareValues.mode_no == 0)
        {
            PlayerData.SelectedLevelID = levelNum;
            nextBtn.gameObject.SetActive(true);
            selectImages[levelNum].gameObject.SetActive(true);

            // int a = levelNum + 1;
            // selectImages[levelNum].gameObject.SetActive(true);
            //   SSTools.ShowMessage("Level_No: " + a + " Is Selectected", SSTools.Position.bottom, SSTools.Time.threeSecond);
        }
    }

    public void NextBtnClickd()
    {
        //LoadingData.sceneName = "01_Game";
        //AsyncLoading._instance.LoadScene();
        SceneManager.LoadScene("01_Game");
    }
    
    public void BackBtnClicked()
    {
        SceneManager.LoadScene("02_CharacterSelection");
    }

    void UnselectLevelBtn()
    {
        for(int i= 0; i< selectImages.Length; i++)
        {
            selectImages[i].gameObject.SetActive(false);
        }
    }
    void All_Panel_Off()
    {
        Debug.LogError(PlayerData.TotalLevelUnlocked());
        for(int i= 0; i< Panels.Length; i++)
        {
            Panels[i].gameObject.SetActive(false);
        }
        if (PlayerData.TotalLevelUnlocked() <= 3)
        {
            Panels[0].SetActive(true);
            Content.GetComponent<Panels_Swapping>().Panel_ID = 0;
        }
        else if (PlayerData.TotalLevelUnlocked() >= 4 && PlayerData.TotalLevelUnlocked() <= 6)
        {
            Panels[1].SetActive(true); Content.GetComponent<Panels_Swapping>().Panel_ID = 1;

        }
        else if (PlayerData.TotalLevelUnlocked() >= 7 && PlayerData.TotalLevelUnlocked() <= 9)
        {
            Panels[2].SetActive(true); Content.GetComponent<Panels_Swapping>().Panel_ID = 2;

        }
        else
        {
            Panels[3].SetActive(true); Content.GetComponent<Panels_Swapping>().Panel_ID = 3;
        }
    }
    void AdCoinReward()
    {
        PlayerData.Coins += 100;
        coinText.text = PlayerData.Coins.ToString();
    }
}
   