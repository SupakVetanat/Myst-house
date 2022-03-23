using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Door : MonoBehaviour
{
    [SerializeField] private VideoPlayer Credits;
    [SerializeField] private string scenename;
    [SerializeField] private GameObject triggerActive;

    private ulong endFrame;
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Final" && triggerActive.active && Input.GetKeyDown(KeyCode.E) && GamePlay.instance.Item)
        { 
            endFrame = Credits.frameCount;
            Destroy(GameObject.Find("Canvas"));
            Credits.Play();
            Time.timeScale = 0;


        }
        else if (triggerActive.active && Input.GetKeyDown(KeyCode.E)&&GamePlay.instance.Item)
        {
            SceneManager.LoadScene(scenename);
        }
        if (SceneManager.GetActiveScene().name == "Final" && (ulong)Credits.frame == endFrame-2 && Credits.isPlaying)
        {
            SceneManager.LoadScene("Menu");

        }
        
    }
}
