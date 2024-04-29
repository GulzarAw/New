
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CharacterSelectionManager : MonoBehaviour
{
  
    public GameObject[] characterModles;
    public CharacterStats[] characterStats;
    public Button leftBtn, rightBtn, buyButton, nextButton, backButton;
    public Image powerBar, rangeBar, damageBar, reloadBar , priceBG , coinBG;
    public Text characterName, characterPrice, coins;
    public GameObject enogh_Coins;    
    public GameObject All_Char;    

    private int characterID = 0;
    public Camera cam;

    private void Awake()
    {
        characterID = PlayerData.SelectedCharacterID;
        All_Char = GameObject.FindGameObjectWithTag("Characters");
    }

    private void OnEnable()
    {
        coins.text = PlayerData.Coins.ToString();
        characterID = PlayerData.SelectedCharacterID;
        All_Char = GameObject.FindGameObjectWithTag("Characters");
        for (int i = 0; i < All_Char.transform.childCount; i++)
        {
            characterModles[i] = All_Char.transform.GetChild(i).gameObject;
        }
        All_Character_off();
        characterModles[characterID].SetActive(true);
       // coins.text = PlayerData.Coins.ToString();
        UpdateStats();
        // backButton.GetComponent<DOTweenAnimation>().DORestart();
        // coinBG.GetComponent<DOTweenAnimation>().DORestart();
        cam.gameObject.SetActive(true);
        Canvas canvas = GameObject.FindGameObjectWithTag("Can").GetComponent<Canvas>();
        // cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cam;
        }
    }
    public void LeftBtnClicked()
    {
        All_Character_off();
        characterID--;
        if(characterID < 0)
        {
            characterID = characterModles.Length - 1;
        }
        characterID = Mathf.Clamp(characterID, 0, characterModles.Length - 1);
        characterModles[characterID].SetActive(true);
        UpdateStats();
    }

    public void RightBtnClicked()
    {
        All_Character_off();
        characterID++;
        if(characterID > characterModles.Length -1)
        {
            characterID = 0;
        }
        characterID = Mathf.Clamp(characterID, 0, characterModles.Length - 1);
        characterModles[characterID].SetActive(true);
        UpdateStats();
    }
    public void All_Character_off()
    {
        for (int i = 0; i < All_Char.transform.childCount; i++)
        {
            characterModles[i].SetActive(false);
        }
    }
    public void BuyBthClicked()
    {
        if (PlayerData.Coins >= characterStats[characterID].Price)
        {
            PlayerData.Coins -= characterStats[characterID].Price;
            PlayerData.UnlockCharacter(characterID);
            buyButton.gameObject.SetActive(false);
            ////priceBG.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
            coins.text = PlayerData.Coins.ToString();
            nextButton.GetComponent<DOTweenAnimation>().DORestart();
        }
        else
        {
            //shopPanel.gameObject.SetActive(true);
        }
    }

    public void SelectBtnClicked()
    {
   //     DisableAllCharacter();
        PlayerData.SelectedCharacterID = characterID;
    }

    public void BackBtnClicked()
    {
        SceneManager.LoadScene("00_MainMenu");
    }

    private void UpdateStats()
    {
        PlayerData.SelectedCharacterID = characterID;
        if (PlayerData.IsCharacterLocked(characterID))
        {
            buyButton.gameObject.SetActive(true);
            //buyButton.GetComponent<DOTweenAnimation>().DORestart();
         //   priceBG.gameObject.SetActive(true);
            //priceBG.GetComponent<DOTweenAnimation>().DORestart();
            nextButton.gameObject.SetActive(false);
          //  Debug.LogError("locked");
        }
        else
        {
           // Debug.LogError("Unlocked");
            buyButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
            //nextButton.GetComponent<DOTweenAnimation>().DORestart();            
         //   priceBG.gameObject.SetActive(false);
        }
      
       // DisableAllCharacter();
        characterModles[characterID].SetActive(true);
        characterPrice.text = characterStats[characterID].Price.ToString();
        DOTween.To(() => powerBar.fillAmount, x => powerBar.fillAmount = x, characterStats[characterID].power, 2f).SetEase(Ease.OutBounce);
        DOTween.To(() => damageBar.fillAmount, x => damageBar.fillAmount = x, characterStats[characterID].damage, 2f).SetEase(Ease.OutBounce);
        DOTween.To(() => reloadBar.fillAmount, x => reloadBar.fillAmount = x, characterStats[characterID].reload, 2f).SetEase(Ease.OutBounce);
        DOTween.To(() => rangeBar.fillAmount, x => rangeBar.fillAmount = x, characterStats[characterID].range, 2f).SetEase(Ease.OutBounce);
    }
}

   