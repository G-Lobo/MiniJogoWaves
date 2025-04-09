using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTransform;
    void Update()
    {
        if (playerTransform)
        {
            transform.position = playerTransform.position + new Vector3(0,0,-10);
        }
    }
}
