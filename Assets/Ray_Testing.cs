using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Testing : MonoBehaviour
{
    public GameObject Last_Hit;
    public Play_Partile play_Partile;
    public Vector3 collision = Vector3.zero;
    

    void Update()
    {
        var ray = new Ray(this.transform.position,this.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit ,70) )
        {
            Last_Hit = hit.transform.gameObject;
            collision = hit.point;
        }
        if(Last_Hit  && Last_Hit.name == "Cube")
        {
            play_Partile.Play_particle();
            Last_Hit = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(collision, .6f);
    }
}

   