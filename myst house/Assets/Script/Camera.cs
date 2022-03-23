using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{


    [SerializeField] private Transform player;

    private float defualtCamera;
    private float nextCamera;

    void Update()
    {
        defualtCamera = transform.position.x;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    }

    private void LateUpdate()
    {
        nextCamera = transform.position.x;


    }
}
