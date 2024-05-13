using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters_Portrair : MonoBehaviour
{
    public int current_Char;
    public GameObject[] Chars;

    // Start is called before the first frame update
    void Start()
    {
        current_Char = PlayerData.SelectedCharacterID;
        All_Chars_Off();
        Chars[current_Char].SetActive(true);
    }

    private void OnEnable()
    {
        current_Char = PlayerData.SelectedCharacterID;
        All_Chars_Off();
        Chars[current_Char].SetActive(true);
    }
    public void All_Chars_Off()
    {
        for (int i = 0; i < Chars.Length; i++)
        {
            Chars[i].SetActive(false);
        }
    }
}
