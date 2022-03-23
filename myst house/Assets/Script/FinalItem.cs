using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalItem : MonoBehaviour
{
    private Dialogue dialogue;
    public static FinalItem instance;
    [SerializeField] private GameObject ItemUI;
    [SerializeField] private GameObject triggerActive;

    private void Start()
    {

        dialogue = GetComponent<Dialogue>();
    }
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (triggerActive.active && Input.GetKeyDown(KeyCode.E) && !GamePlay.instance.finished)
        {
            GamePlay.instance.getItem();
        }

    }
    public void showItemUI()
    {
            GamePlay.instance.getItem();
            ItemUI.SetActive(true);
            UIManager.instance.hidePanal();
            Time.timeScale = 0;
            string[] sentences = { "shadow’s voice : \"looks like you are quite clever.\" ", "shadow’s voice : \"i’ll let you go little girl, good luck\"", "*door open*" };
            dialogue.sentences = sentences;
    }
    public void hideItemUI()
    {
        ItemUI.SetActive(false);
        DialogueTrigger.instance.TriggerDialogue(dialogue);
        UIManager.instance.chatBoxActive();
        GamePlay.instance.finished = true;
        string[] sentences = { "Player : \"I really wanted to get out of this place.\"" };
        dialogue.sentences = sentences;
    }
}
