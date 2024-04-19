using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enabling : MonoBehaviour
{
    public GameObject Camera;
    private void OnEnable()
    {
        Camera.SetActive(false);
    }
}
