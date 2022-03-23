using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Dialogue dialogue;
    [SerializeField] private GameObject triggerActive;
    void Start()
    {
        dialogue = GetComponent<Dialogue>();
    }
    void Update()
    {
        if (triggerActive.active && Input.GetKeyDown(KeyCode.E)&&!GamePlay.instance.finished)
                {
                    GamePlay.instance.getItem();
                    StartCoroutine(Delaydialogue());
                }
        
    }
    IEnumerator Delaydialogue()
    {
        yield return new WaitForSeconds(1f);
        string[] sentences = { "Player :  \"I need to go to the next room\" " };
        dialogue.sentences = sentences;
    }
}
