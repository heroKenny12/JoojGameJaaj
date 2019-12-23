using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CamConfig")]
    [SerializeField]
    private Transform player;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z - 22.5f);
    }
}
