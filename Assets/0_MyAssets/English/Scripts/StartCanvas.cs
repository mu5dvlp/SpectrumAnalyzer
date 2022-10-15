using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] GameObject blocker;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Start()
    {
        blocker.SetActive(true);
    }

    public void OnBtnPush_start()
    {
        blocker.SetActive(false);
        DebugCanvas.i.StartTimer();
    }
}
