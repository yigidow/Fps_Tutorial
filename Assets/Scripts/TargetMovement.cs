using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public bool shouldMove, shouldRotate;
    public float moveSpeed, rotateSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            transform.position += new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
        }
        
    }
}
