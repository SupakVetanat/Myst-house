using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [SerializeField] private AudioClip gui;

    [SerializeField] private AudioSource audioSource;
    public static Audiomanager instance;

    private void Awake()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.2f;
    }
    public void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    public void playGui()
    {
        playSound(gui);
    }
}
