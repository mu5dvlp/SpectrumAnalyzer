using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager i;
    [SerializeField] BarCanvasController barCanvasController;
    [SerializeField] AverageCanvasController averageCanvasController;
    [SerializeField] SaveDataBarCanvasController saveDataBarCanvasController;
    [SerializeField] MenuCanvasController menuCanvasController;


    [Space(40)]
    [Header("通常のバー 設定")]
    public BarCount barCount = BarCount.Count_64;
    public DisplayMode displayMode = DisplayMode.Full;
    public int limitedBarCount = 100;
    public float barSpan = 10;

    [Space(20)]
    [Header("平均のバー 設定")]
    public float averageSumThreshold = 1;
    public float averageBarMaginification = 1;

    [Space(20)]
    [Header("最大のバー 設定")]
    public bool showMaxBars = true;

    [Space(20)]
    [Header("セーブのバー 設定")]
    public bool showSaveBars = true;
    public SaveDataMode saveData_show = SaveDataMode.MasanoriMorise;

    [Space(20)]
    [Header("メニュー")]
    public SaveDataMode saveData_target = SaveDataMode.Hina;
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

        averageCanvasController.averageSumThreshold = averageSumThreshold;
        averageCanvasController.averageBarMaginification = averageBarMaginification;

        saveDataBarCanvasController.saveDataMode = saveData_show;

        menuCanvasController.saveDataMode = saveData_target;
        menuCanvasController.saveShowMode = saveData_show;
    }
}
