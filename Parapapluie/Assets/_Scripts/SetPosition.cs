using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public string Tag;
    GameObject Target;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag(Tag);
    }

    void Update()
    {
        transform.position = Target.transform.position;
    }
}
