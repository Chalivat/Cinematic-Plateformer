using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDrop : MonoBehaviour
{
    public GameObject Drop;
    public float frequency;
    private float time;
    

    
    void Update()
    {
        Timer();
    }

    void DropWater()
    {
        Instantiate(Drop, transform.position, Drop.transform.rotation);
    }

    void Timer()
    {
        time += Time.deltaTime;
        if (time >= frequency)
        {
            DropWater();
            time = 0;
        }
    }
}
