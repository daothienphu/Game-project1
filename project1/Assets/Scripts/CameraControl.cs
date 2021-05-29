using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 0.75f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Slerp(this.transform.position, player.transform.position + Vector3.back * 10, moveSpeed * Time.deltaTime);  
    }
}
