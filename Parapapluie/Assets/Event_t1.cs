using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Event_t1 : MonoBehaviour
{
    bool Event_encours = false;

    bool Event_done = false;

    public GameObject Camera_event;
    public GameObject Camera_joueur;
    public GameObject Camera_intro;
    public GameObject foudre;

    public Character_Control charaControl;

    float timer;

    private void Start()
    {
        StartCoroutine(Intro());
    }

    void Update()
    {
        Event();
    }

    void Event()
    {
        if (Event_encours)
        {
            timer += Time.deltaTime;
            Camera_event.SetActive(true);
            Camera_joueur.SetActive(false);
            charaControl.enabled = false;
            if (timer >= 4.9f)
            {
                Camera_event.SetActive(false);
                Camera_joueur.SetActive(true);
                charaControl.enabled = true;
            }
        }
    }

    IEnumerator Intro()
    {
        charaControl.enabled = false;
        yield return new WaitForSeconds(7.5f);
        foudre.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Camera_intro.SetActive(false);
        foudre.SetActive(false);
        charaControl.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Event_done == false)
            {
                Event_done = true;
                Event_encours = true;
            }
        }
    }
}
