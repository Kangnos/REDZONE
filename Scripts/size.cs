using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 objectSize = Vector3.Scale(transform.localScale, GetComponent().mesh.bounds.size)
        var planeScale = 10.0;
    }
    
    function Update () {
        Debug.Log(objectSize); 
    }
}
