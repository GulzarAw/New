using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panels_Swapping : MonoBehaviour
{
    public GameObject[] Level_Panels;
    public  int Panel_ID = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LeftBtnClicked()
    {
        All_Panels_off();
        Panel_ID--;
        if (Panel_ID < 0)
        {
            Panel_ID = Level_Panels.Length - 1;
        }
        Level_Panels[Panel_ID].SetActive(true);
    }

    public void RightBtnClicked()
    {
        All_Panels_off();
        Panel_ID++;
        if (Panel_ID > Level_Panels.Length - 1)
        {
            Panel_ID = 0;
        }
        Level_Panels[Panel_ID].SetActive(true);

    }
    public void All_Panels_off()
    {
        for (int i = 0; i < Level_Panels.Length; i++)
        {
            Level_Panels[i].SetActive(false);
        }
    }
}

   