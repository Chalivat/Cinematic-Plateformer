using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class Disjoncteur_Behaviour : MonoBehaviour
{
    public GameObject Ventilateur;
    public ParticleSystem ps;
    public GameObject Sparks;
    public float stopTime;
    private bool isEnabled;
    float time;
    void Start()
    {
        Ventilateur.SetActive(true);
        isEnabled = true;
    }
    
    void Update()
    {
        Activate();
        Ventilateur.GetComponent<Ventilateur_Behaviour>().isActive = isEnabled;
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drop"))
        {
            isEnabled = false;
            Destroy(other.gameObject);
            var em = ps.emission;
            em.enabled = false;
        }
    }

    void Activate()
    {
        if (!isEnabled)
        {
            time += Time.deltaTime;
            if (time >= stopTime)
            {
                time = 0;
                isEnabled = true;
                var em = ps.emission;
                em.enabled = true;
            }
        }
    }


}
