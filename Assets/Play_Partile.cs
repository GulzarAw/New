using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Partile : MonoBehaviour
{
    public ParticleSystem Blast;
    private void Start()
    {
      //  InvokeRepeating("Play_particle", 1.5f,2f);
    }
    public void Play_particle()
    {
        Blast.gameObject.SetActive(true);
        Blast.Play();
        StartCoroutine(Stops());
    } 
    IEnumerator Stops()
    {
        yield return new WaitForSeconds(0.6f);
        Stop_particle();
    }

    public void Stop_particle()
    {
        Blast.Stop();
        Blast.gameObject.SetActive(false);
    }
}

   