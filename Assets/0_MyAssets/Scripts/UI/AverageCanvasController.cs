using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class AverageCanvasController : MonoBehaviour
{
    public static AverageCanvasController i;

    [SerializeField] AverageBarController averageBar_original;

    [Space(20)]
    [HideInInspector] public float averageSumThreshold = 1;
    [HideInInspector] public float averageBarMaginification = 1;

    float[] spectrum_ave;
    [HideInInspector] public List<AverageBarController> averageBars = new List<AverageBarController>();

    public AverageBarController MaxBar
    {
        get
        {
            float max = spectrum_ave[0];
            AverageBarController averageBar_max = averageBars[0];
            for (int i = 1; i < averageBars.Count; i++)
            {
                if (averageBars[i].Value > max)
                {
                    max = averageBars[i].Value;
                    averageBar_max = averageBars[i];
                }
            }
            return averageBar_max;
        }
    }

    public int MaxBarNumber
    {
        get
        {
            int maxNumber = 0;
            float max = spectrum_ave[0];
            for (int i = 1; i < averageBars.Count; i++)
            {
                if (averageBars[i].Value > max)
                {
                    max = averageBars[i].Value;
                    maxNumber = i;
                }
            }
            return maxNumber;
        }
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
    }

    void Start()
    {
        if (BarCanvasController.i.displayMode == DisplayMode.Full) spectrum_ave = new float[(int)BarCanvasController.i.barCount];
        else if (BarCanvasController.i.displayMode == DisplayMode.Limit) spectrum_ave = new float[8192];

        MakeBar();
    }

    void Update()
    {
        Analyze();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void MakeBar()
    {
        if (BarCanvasController.i.displayMode == DisplayMode.Full)
        {
            for (int i = 0; i < (int)BarCanvasController.i.barCount; i++)
            {
                AverageBarController bar_clone = Instantiate(averageBar_original);
                bar_clone.Initialize(transform, i, -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / (float)BarCanvasController.i.barCount);
                averageBars.Add(bar_clone);
            }
        }
        else
        {
            for (int i = 0; i < BarCanvasController.i.LimitedBarCount; i++)
            {
                AverageBarController bar_clone = Instantiate(averageBar_original);
                bar_clone.Initialize(transform, i, -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / BarCanvasController.i.LimitedBarCount);
                averageBars.Add(bar_clone);
            }
        }
    }

    void Analyze()
    {
        if (BarCanvasController.i.BarSum < averageSumThreshold) return;

        for (int i = 0; i < averageBars.Count; i++)
        {
            averageBars[i].AddData(InputSoundManager.i.spectrum[i], BarCanvasController.i.BarSum);
        }
    }

    [ContextMenu("平均リセット")]
    public void Reset()
    {
        for (int i = 0; i < averageBars.Count; i++)
        {
            averageBars[i].ResetData();
        }
    }
}