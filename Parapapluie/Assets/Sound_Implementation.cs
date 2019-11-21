using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Implementation : MonoBehaviour
{
    Character_Control scriptPlayer;
    Parapluie_Behaviour scriptParapluie;
    public AudioSource[] audioSources;
    public AudioClip[] pas;
    public AudioClip[] parapluie;
    float time;
    bool flip = false;

    void Start()
    {
        scriptPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_Control>();
        scriptParapluie = GameObject.FindGameObjectWithTag("Player").GetComponent<Parapluie_Behaviour>();
    }
    
    void Update()
    {
        if(scriptPlayer.isGrounded && (Input.GetAxis("Horizontal") >= 0.9 || Input.GetAxis("Horizontal") <= -0.9))
        {
            time += Time.deltaTime;
            if(time >= 1f)
            {
                time = 0;
                audioSources[0].clip = pas[Random.Range(0, pas.Length)];
                audioSources[0].Play();
            }
        }

        if (scriptParapluie.hasParapluie)
        {
            if (!flip)
            {
                flip = true;
                audioSources[0].clip = parapluie[Random.Range(0, parapluie.Length)];
                audioSources[0].Play();
            }
        }
        else if (!scriptParapluie.hasParapluie)
        {
            if (flip)
            {
                flip = false;
                audioSources[0].clip = parapluie[Random.Range(0, parapluie.Length)];
                audioSources[0].Play();
            }
        }
    }
}
