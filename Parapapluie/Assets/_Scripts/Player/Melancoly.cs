using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melancoly : MonoBehaviour
{
    private float melancoly;
    public float rate;
    public bool isInPluie;
    public bool isMelancoly;
    void Start()
    {
        
    }
    
    void Update()
    {
        Melancoling();

        if (melancoly > 0.9f)
        {
            isMelancoly = true;
        }
        else isMelancoly = false;
    }

    void Melancoling()
    {
        if (!Input.GetKey(KeyCode.Space) && isInPluie)
        {
                melancoly += Time.deltaTime;
        }
            else
                melancoly -= Time.deltaTime;

        melancoly = Mathf.Clamp01(melancoly);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pluie"))
        {
            isInPluie = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pluie"))
        {
            isInPluie = false;
        }
    }




}
