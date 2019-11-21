using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Ventilateur_Behaviour : MonoBehaviour
{
    public float WindStrengh;
    private int collisionCount;
    private Character_Control characterControl;
    private Rigidbody player;
    public bool isActive;

    private Collider coll;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        characterControl = player.gameObject.GetComponent<Character_Control>();
        coll = GetComponent<Collider>();
    }
    
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position + transform.up * coll.bounds.size.y);
        if (Input.GetKey(KeyCode.Space) && collisionCount > 0 && isActive && distance >= 5f)
        {
            //player.AddForce(transform.up * WindStrengh,ForceMode.VelocityChange);
            AlignPlayerToWind();
            Vector3 target = transform.position + transform.up * coll.bounds.size.y;
            Vector3 direction = target - player.position;
            player.velocity = direction.normalized * WindStrengh * 5;
        }
        //Debug.DrawRay(transform.position,transform.up,Color.blue,2f);
    }



    void AlignPlayerToWind()
    {

        Vector3 direction = transform.up * coll.bounds.size.y;


        //Vector3 direction = player.transform.position - transform.position;
        //Vector3 newDirection = Vector3.Project(direction, transform.up);
        //player.velocity = ((transform.position + newDirection) - player.position).normalized * WindStrengh;
        //Debug.DrawRay(transform.position, direction, Color.red);
        //Debug.DrawRay(player.transform.position, (newDirection - player.transform.position.normalized).normalized, Color.yellow);

        //Vector3 direction = player.transform.position - transform.position;
        //Vector3 newDirection = player.transform.up * direction.magnitude;
        //Vector3 finalDirection = newDirection - player.transform.position;
        //player.velocity = finalDirection * WindStrengh;
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
