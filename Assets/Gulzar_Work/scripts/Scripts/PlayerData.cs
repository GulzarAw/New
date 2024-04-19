using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    private static int coins = 250;
    private static int selectedModeID;
    private static int selectedLevelID;
    private static int selectedParkingLevelID;
    private static int selectedCaracterID;
    private static int Total_Levels = 20;
    private static int total_Levels_Unlocked = 1;
    private static int total_Levels_Parking_Unlocked;
    public static int Coins
    {
        get
        {
            return coins;
        }
        set
        {
            coins = value;
        }
    }

    public static int SelectedModeID
    {
        get
        {
            return selectedModeID;
        }
        set
        {
            selectedModeID = value;
        }
    }

    public static int SelectedLevelID
    {
        get
        {
            return selectedLevelID;
        }
        set
        {
            selectedLevelID = value;
        }
    }
    
    public static int SelectedCharacterID
    {
        get
        {
            return selectedCaracterID;
        }
        set
        {
            selectedCaracterID = value;
        }
    } 
    
    public static int Total_Levels_Unlocked
    {
        get
        {
            return total_Levels_Unlocked;
        }
        set
        {
            total_Levels_Unlocked = value;
        }
    }

    public static bool IsCharacterLocked(int id)
    {
        if (id == 0)
            return false;
        else
        {
            if (PlayerPrefs.HasKey("Character_id" + id))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public static void UnlockCharacter(int id)
    {
       if(! PlayerPrefs.HasKey("Character_id" + id))
        {
            PlayerPrefs.SetInt("Character_id" + id, 1);
        }
    }
    public static int TotalLevelUnlocked()
    {
        return Total_Levels_Unlocked;
    }
    
    public static int TotalLevelUnlocked_Parking()
    {
        return Total_Levels_Unlocked;
    }

}  