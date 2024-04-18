using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_Player : MonoBehaviour
{
    public float Y_Value;
    public GameObject player_ref;
    public ParticleSystem Stage_Particle;
    private void OnEnable()
    {
        this.transform.rotation = Quaternion.Euler(0f, Y_Value, 0f);
        Stage_Particle.Play();
    }
}