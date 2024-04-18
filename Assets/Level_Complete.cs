using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Complete : MonoBehaviour
{
    public GameObject All_Char;
    // Start is called before the first frame update
    void Start()
    {
        All_Char = GameObject.FindGameObjectWithTag("Games");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level_Next_button()
    {
        GamaManager.Inst.AllButtonHandler_Function("next");
    }    
    public void Level_Restart_button()
    {
        GamaManager.Inst.AllButtonHandler_Function("restart");
    }  
    public void Level_Home_button()
    {
        GamaManager.Inst.AllButtonHandler_Function("home");
    }
}  