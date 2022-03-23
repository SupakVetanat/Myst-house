using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform clockHandTransform;
    private void Awake()
    {
        clockHandTransform = transform.Find("Clockhand1");
    }
    private void Update()
    {
        clockHandTransform.eulerAngles = new Vector3(0, 0, -Time.timeSinceLevelLoad * speed);
        if ((-Time.timeSinceLevelLoad * speed) <= -360)
        {
            GamePlay.instance.gameOver();
        }
    }
}
