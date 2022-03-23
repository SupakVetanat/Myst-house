using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGamePlay : MonoBehaviour
{
    [SerializeField] public int numItem;
    [SerializeField] public int onItem;
    public static FinalGamePlay instance;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(onItem == 4&&numItem == 4 && !GamePlay.instance.finished)
        {
            FinalItem.instance.hideItemUI();
            GamePlay.instance.finished = true;
        }
        else if (onItem == 4 && numItem != 4)
        {
            GamePlay.instance.gameOver();
        }
    }
}
