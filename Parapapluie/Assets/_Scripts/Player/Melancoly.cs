using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melancoly : MonoBehaviour
{
    private float melancoly;
    public float rate;
    public bool isInPluie;
    public bool isInCascade;
    public bool isMelancoly;

    private int CascadeCount;
    void Start()
    {
        particles = new List<GameObject>();
    }
    
    void Update()
    {
        Debug.Log(" Gros CON : " + melancoly);
        Cascading();
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


    void Cascading()
    {
        if (CascadeCount > 0)
        {
            melancoly = 1;
            isInCascade = true;
        }
        else isInCascade = false;
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

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Ouille");
        if (other.gameObject.CompareTag("Cascade"))
        {
            CascadeCount++;
        }
    }

    private List<GameObject> particles;
    void Sort(GameObject other)
    {
            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i] == null)
                {
                    CascadeCount--;
                    particles.Remove(particles[i]);
                }
            
            }
        }
    }







