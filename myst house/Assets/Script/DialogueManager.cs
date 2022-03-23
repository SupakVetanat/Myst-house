using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Queue<string> sentences;
    public Text dialogueText;

    [SerializeField] private GameObject item;
    [SerializeField] private GameObject choice;
    [SerializeField] private GameObject dialogue;
    [SerializeField] public bool isEnd = false;
    [SerializeField] public bool isStart = false;

    private void Awake()
    {
        instance = this;
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        isStart = true;
        isEnd = false;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
            DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        isStart = false;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }
    void EndDialogue()
    {
        if ( SceneManager.GetActiveScene().name == "SampleScene"|| (SceneManager.GetActiveScene().name == "Final" && !GamePlay.instance.Item)
            || (SceneManager.GetActiveScene().name == "Final" && GamePlay.instance.finished))
        {
            UIManager.instance.hidePanal();
            isEnd = true;
        }

        else if (SceneManager.GetActiveScene().name == "Final" && GamePlay.instance.Item  && !GamePlay.instance.finished)
        {
            FinalItem.instance.showItemUI();
        }
        else if (GamePlay.instance.Item && !item.active && !GamePlay.instance.finished)
        {
            choice.SetActive(true);
        }
        else if (!choice.active)
        {
            UIManager.instance.hidePanal();
            isEnd = true;
            item.SetActive(false);

        }
    }
}

