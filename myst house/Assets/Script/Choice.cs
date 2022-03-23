using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    [SerializeField] private GameObject ChoiceUI;
    [SerializeField] private GameObject Item;
    [SerializeField] private Dialogue dialogue;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

    }
    public void trueChoice()
    {
        DialogueTrigger.instance.TriggerDialogue(dialogue);
        UIManager.instance.chatBoxActive();
        Item.SetActive(true);
        ChoiceUI.SetActive(false);
        GamePlay.instance.finished = true;

    }
    public void falseChoice()
    {
        GamePlay.instance.gameOver();
    }
}
