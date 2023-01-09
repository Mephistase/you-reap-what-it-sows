using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainbow_spin : MonoBehaviour
{
    public Vector3 spin=new Vector3(0f,0f,1f);

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Rotate(spin);
    }
}
