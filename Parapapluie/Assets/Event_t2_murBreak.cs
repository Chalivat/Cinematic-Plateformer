using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_t2_murBreak : MonoBehaviour
{
    public GameObject Mur_break;
    public GameObject Particles_pluie;
    public GameObject Particles_explosion;


    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mur_break.SetActive(false);
            Particles_pluie.SetActive(true);
            Particles_explosion.SetActive(true);
        }
    }
}
