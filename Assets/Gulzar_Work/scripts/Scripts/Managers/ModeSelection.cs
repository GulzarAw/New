using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ModeSelection : MonoBehaviour
{
    public GameObject Unlock_All;
    public Animator Ui_Mode_Sel;
    public GameObject levelSelectionPanel;
    public GameObject levelSelectionPanel_Parking;

    public GameObject robotSelectionPanel;
    public Image coinBG, selectionText;
    public Button backButton;
    public Button buttonNext;
    public Image highlightImage;
    public Image highlightImage1;

    public Text coinText;
    private void OnEnable()
    {
        buttonNext.gameObject.SetActive(false);
        backButton.GetComponent<DOTweenAnimation>().DORestart();
        coinBG.GetComponent<DOTweenAnimation>().DORestart();
        coinText.text = PlayerData.Coins.ToString();
    }
    
    public void SelectMode(int modeID)
    {
        PlayerData.SelectedModeID = modeID;
        switch(modeID)
        {
            case 0:
                ShareValues.mode_no = 0;
                highlightImage.gameObject.SetActive(true);
                highlightImage1.gameObject.SetActive(false);

                buttonNext.gameObject.SetActive(true);

                break;
            case 1:
                ShareValues.mode_no = 1;

                highlightImage.gameObject.SetActive(false);

                highlightImage1.gameObject.SetActive(true);
                buttonNext.gameObject.SetActive(true);
                break;
        }
    }


    public void NextButtonClicked()
    {
       if(ShareValues.mode_no == 0)
        {
            this.gameObject.SetActive(false);
            levelSelectionPanel.SetActive(true);
        }
       else
        {
            this.gameObject.SetActive(false);
            levelSelectionPanel_Parking.SetActive(true);
        }
    }


    public void BackButtonClicked()
    {
        this.gameObject.SetActive(false);
        robotSelectionPanel.SetActive(true);
    }

    void AdCoinReward()
    {
        PlayerData.Coins += 100;
        coinText.text = PlayerData.Coins.ToString();
    }
}


   