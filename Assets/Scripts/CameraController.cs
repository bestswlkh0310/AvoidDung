using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0.0f, 10.0f, -20.0f);
        transform.rotation = Quaternion.Euler(20.0f, 0.0f, 0.0f);
    }
}
