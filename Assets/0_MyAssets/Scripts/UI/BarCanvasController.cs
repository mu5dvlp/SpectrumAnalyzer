using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarCount
{
    [InspectorName("64")] Count_64 = 64,
    [InspectorName("128")] Count_128 = 128,
    [InspectorName("256")] Count_256 = 256,
    [InspectorName("512")] Count_512 = 512,
    [InspectorName("1024")] Count_1024 = 1024,
    [InspectorName("2048")] Count_2048 = 2048,
    [InspectorName("4096")] Count_4096 = 4096,
    [InspectorName("8192")] Count_8192 = 8192
}

public enum DisplayMode
{
    Full,
    Limit
}

public class BarCanvasController : MonoBehaviour
{
    public static BarCanvasController i;

    [SerializeField] BarController bar_original;

    [Space(20)]
    [HideInInspector] public BarCount barCount = BarCount.Count_64;
    [HideInInspector] public DisplayMode displayMode = DisplayMode.Full;
    [HideInInspector] public int limitedBarCount = 100;
    public int LimitedBarCount { get { return limitedBarCount; } }
    [HideInInspector] public float barSpan = 10;
    public float BarSpan { get { return barSpan; } }

    public float BarSpace { get { return (float)Screen.width - 100 / (float)barCount; } }

    public float BarSum
    {
        get
        {
            float sum = 0;
            for (int i = 0; i < bars.Count; i++)
            {
                sum += bars[i].Value;
            }
            return sum;
        }
    }

    public BarController MaxBar
    {
        get
        {
            float max = InputSoundManager.i.spectrum[0];
            BarController bar_max = bars[0];
            for (int i = 1; i < bars.Count; i++)
            {
                if (bars[i].Value > max)
                {
                    max = bars[i].Value;
                    bar_max = bars[i];
                }
            }
            return bar_max;
        }
    }

    public int MaxBarNumber
    {
        get
        {
            int maxBarNumber = 0;
            float max = InputSoundManager.i.spectrum[0];
            for (int i = 1; i < bars.Count; i++)
            {
                if (bars[i].Value > max)
                {
                    max = bars[i].Value;
                    maxBarNumber = i;
                }
            }
            return maxBarNumber;
        }
    }

    [HideInInspector] public List<BarController> bars = new List<BarController>();

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeBar();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void SearchChildBar()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out BarController bar_child))
            {
                bars.Add(bar_child);
            }
        }
    }

    void MakeBar()
    {
        if (displayMode == DisplayMode.Full)
        {
            for (int i = 0; i < (int)barCount; i++)
            {
                BarController bar_clone = Instantiate(bar_original);
                bar_clone.Initialize(transform, i, -barSpan + ((float)Screen.width - 100) / (float)barCount);
                bars.Add(bar_clone);
            }
        }
        else
        {
            for (int i = 0; i < limitedBarCount; i++)
            {
                BarController bar_clone = Instantiate(bar_original);
                bar_clone.Initialize(transform, i, -barSpan + ((float)Screen.width - 100) / limitedBarCount);
                bars.Add(bar_clone);
            }
        }
    }

    public void ChangeBarLength(float[] spectrum)
    {
        if (displayMode == DisplayMode.Full)
        {
            for (int i = 0; i < (int)barCount; i++)
            {
                bars[i].ChangeLength(spectrum[i]);
            }
        }
        else
        {
            for (int i = 0; i < limitedBarCount; i++)
            {
                bars[i].ChangeLength(spectrum[i]);
            }
        }
    }
}
