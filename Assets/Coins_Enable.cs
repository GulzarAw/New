using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins_Enable : MonoBehaviour
{
    public Text Coins_Text;
    private void OnEnable()
    {
        Coins_Text.text = PlayerData.Coins.ToString();
    }
}
