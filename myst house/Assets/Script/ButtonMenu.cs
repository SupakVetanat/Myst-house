using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private VideoPlayer intro;
    [SerializeField] private AudioClip soundMouseOver;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject playButtom;
    [SerializeField] private GameObject ExitButtom;
    [SerializeField] private string sceneName;

    private ulong endFrame;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        endFrame = intro.frameCount;
    }
    public void MouseOversplay()
    {
        playButtom.transform.localScale = new Vector2(1.3f, 1.3f);
        audioSource.PlayOneShot(soundMouseOver);
    }
    public void MousExitplay()
    {
        playButtom.transform.localScale = new Vector2(1f, 1f);
    }
    public void MouseOversExit()
    {
        ExitButtom.transform.localScale = new Vector2(1.3f, 1.3f);
        audioSource.PlayOneShot(soundMouseOver);
    }
    public void MousExitExit()
    {
        ExitButtom.transform.localScale = new Vector2(1f, 1f);
    }
    public void ExitBut()
    {
        Application.Quit();
    }
    public void scene()
   {
        intro.Play();
        playButtom.SetActive(false);
        ExitButtom.SetActive(false);
    }
    private void Update()
    {
        if ((ulong)intro.frame == endFrame-3)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
