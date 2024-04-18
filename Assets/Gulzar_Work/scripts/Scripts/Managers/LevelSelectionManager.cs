using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelSelectionManager : MonoBehaviour
{
    public Button[] levelButtons;
    public Text[] lockImages;
    public Image[] selectImages;
    public Button nextBtn;
    public GameObject modeSelectionPanel;
    public GameObject coinBG;
    public Text coinText;
    public Material Unlocked_Material;

    private void OnEnable()
    {
        // coinBG.GetComponent<DOTweenAnimation>().DORestart();
        //  coinText.text = PlayerData.Coins.ToString();
        PlayerData.Total_Levels_Unlocked = PlayerPrefs.GetInt("LevelsUnlocked",1);
        if (ShareValues.mode_no == 0)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i < PlayerData.TotalLevelUnlocked())
                {
                    levelButtons[i].interactable = true;
                    //  lockImages[i].gameObject.SetActive(false);
                    //lockImages[i].text = "Played";
                }
                else
                {
                    levelButtons[i].interactable = false;
                    //lockImages[i].text = "Play";
                    levelButtons[i].gameObject.GetComponent<Image>().material = null;
                    //lockImages[i].gameObject.SetActive(true);
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
    void AdCoinReward()
    {
        PlayerData.Coins += 100;
        coinText.text = PlayerData.Coins.ToString();
    }
}

   