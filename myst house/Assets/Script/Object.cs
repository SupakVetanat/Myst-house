using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object : MonoBehaviour
{
    [SerializeField] private GameObject triggerActive ;

    [SerializeField] private Dialogue dialogue;
    public string collisionName;
    public bool triggerCollision;

    public static Object instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collisionName==gameObject.name)
        {
            triggerActive.active = true;
            triggerCollision = true;

        }
        else
        {
            triggerActive.active = false;
            triggerCollision = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerActive.active = false;
        triggerCollision = false;
    }

    private void Update()
    {
        collisionName = Player.instance.collisionName;
        if (triggerCollision && Input.GetKeyDown(KeyCode.E) )
        {
            if (SceneManager.GetActiveScene().name != "SampleScene" && (gameObject.tag =="Item") && !GamePlay.instance.finished)
            {
                StartCoroutine(DelayforAnima());
            }
            else 
            {
                DialogueTrigger.instance.TriggerDialogue(dialogue);
                UIManager.instance.chatBoxActive();
            }

        }

    }
    IEnumerator DelayforAnima()
    {
        yield return new WaitForSeconds(0.5f);
        DialogueTrigger.instance.TriggerDialogue(dialogue);
        UIManager.instance.chatBoxActive();
    }
}
