using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager i;
    [SerializeField] BarCanvasController barCanvasController;


    [Space(40)]
    [Header("通常のバー 設定")]
    public BarCount barCount = BarCount.Count_64;
    public DisplayMode displayMode = DisplayMode.Full;
    public int limitedBarCount = 100;
    public float barSpan = 10;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
    }

    void OnValidate()
    {
        barCanvasController.barCount = barCount;
        barCanvasController.displayMode = displayMode;
        barCanvasController.limitedBarCount = limitedBarCount;
        barCanvasController.barSpan = barSpan;
    }
}
