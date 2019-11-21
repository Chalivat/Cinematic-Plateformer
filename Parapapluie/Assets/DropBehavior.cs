using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehavior : MonoBehaviour
{

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }


}
