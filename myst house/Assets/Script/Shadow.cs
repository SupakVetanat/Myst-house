using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] public Animator Anime;
    [SerializeField] private Dialogue dialogue;
    private bool isTriger = false;
    // Start is called before the first frame update
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Anime = GetComponent<Animator>();
    }
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.color = new Color(225, 225, 225, 100);
        Anime.Play("Sha_Kit_in");
    }
    void Update()
    {
        if (DialogueManager.instance.isEnd && isTriger)
        {
            Anime.Play("Sha_Kit_out");
        }
    }
    private void triger()
    {
        UIManager.instance.chatBoxActive();
        DialogueTrigger.instance.TriggerDialogue(dialogue);
        isTriger = true;
    }
    private void destroy()
    {
        isTriger = false;
        Destroy(gameObject);
    }
}
