using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_enabling : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Close_This_Obj());
    }
    IEnumerator Close_This_Obj()

    {
        yield return new WaitForSeconds(1.7f);
        this.gameObject.SetActive(false);  
    }
}
