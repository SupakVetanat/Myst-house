using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow_But : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] public Animator Anime;
    [SerializeField] private GameObject triggerActive;
    [SerializeField] private string animaIn;
    [SerializeField] private string animaOut;
    public bool isTriger = false;

    public static Shadow_But instance;

    private void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
        Anime = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActive.active && Input.GetKeyDown(KeyCode.E) && !GamePlay.instance.finished)
        {
            sr.color = new Color(225, 225, 225, 100);
            Anime.Play(animaIn);
        }
        if (DialogueManager.instance.isEnd && isTriger)
        {
            Anime.Play(animaOut);
        }
    }
    private void triger()
    {
        isTriger = true;
    }
    private void destroy()
    {
        Destroy(gameObject);
    }
}
