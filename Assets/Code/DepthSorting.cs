using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSorting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().transparencySortMode = TransparencySortMode.CustomAxis;
        GetComponent<Camera>().transparencySortAxis = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
