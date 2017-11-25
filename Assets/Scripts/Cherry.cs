using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private float _rotateSpeed = 5.0f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Test");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, _rotateSpeed));
    }

    
}
