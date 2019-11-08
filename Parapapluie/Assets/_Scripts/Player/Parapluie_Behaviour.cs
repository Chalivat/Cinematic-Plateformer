using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parapluie_Behaviour : MonoBehaviour
{
    private bool hasParapluie;

    public GameObject Parapluie;
    private Rigidbody rb;
    public float normalDrag, ParapluieDrag,groundedDrag;

    private bool isInVentilator;
    private Melancoly melancoly;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RentrerParapluie();
        normalDrag = rb.drag;
        melancoly = GetComponent<Melancoly>();
    }
    
    void Update()
    {
        ToggleParapluie();
        adaptDrag();
        adaptToPluie();
    }

    void ToggleParapluie()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                SortirParapluie();
                hasParapluie = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
                RentrerParapluie();
                hasParapluie = false;
        }
    }

    void SortirParapluie()
    {
        Parapluie.SetActive(true);
        rb.drag = ParapluieDrag;
    }

    void RentrerParapluie()
    {
        Parapluie.SetActive(false);
        rb.drag = normalDrag;
    }

    void adaptDrag()
    {
       
        if (isInVentilator && hasParapluie)
        {
            rb.drag = normalDrag;
        }
        else if (hasParapluie)
        {
            rb.drag = ParapluieDrag;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            rb.drag = groundedDrag;
        }
    }

    void adaptToPluie()
    {
        if (hasParapluie & melancoly.isMelancoly)
        {
            RentrerParapluie();
            hasParapluie = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ventilateur"))
        {
            isInVentilator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ventilateur"))
        {
            isInVentilator = false;
        }
    }
}
