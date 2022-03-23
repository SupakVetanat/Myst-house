using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject panal;

    [SerializeField] private GameObject Pause;

    [SerializeField] private Dialogue dialogue;

    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        DialogueTrigger.instance.TriggerDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        pauseGame();
    }
    public void showMenu()
    {
        Pause.SetActive(true);
        Time.timeScale = 0;

    }
    public void hidePanal()
    {
        Audiomanager.instance.playGui();
        panal.SetActive(false);
        Time.timeScale = 1;
    }
    public void hideMenu()
    {
        Audiomanager.instance.playGui();
        Pause.SetActive(false);
        if(!panal.active)
        {
        Time.timeScale = 1;
        }
    }
    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu();
        }
    }
    public void chatBoxActive()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
        panal.SetActive(true);
    }
}
