using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Text : MonoBehaviour
{
    public int currentLevel;
    public GameObject[] Levels;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = PlayerData.SelectedLevelID;
        All_Levels_Off();
        Levels[currentLevel].SetActive(true);
    }

    private void OnEnable()
    {
        currentLevel = PlayerData.SelectedLevelID;
        All_Levels_Off();
        Levels[currentLevel].SetActive(true);
    }
    public void All_Levels_Off()
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }
    }
   
}
