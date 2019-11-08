using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Ventilateur_Behaviour : MonoBehaviour
{
    public float WindStrengh;
    private int collisionCount;
    private Character_Control characterControl;
    private Rigidbody player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        characterControl = player.gameObject.GetComponent<Character_Control>();
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && collisionCount > 0)
        {
           player.velocity = player.velocity + (transform.up * WindStrengh);
           
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collisionCount++;
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collisionCount--;
        }
        
    }


}
