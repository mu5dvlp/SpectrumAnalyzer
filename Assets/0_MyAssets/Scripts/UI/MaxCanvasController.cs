using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxCanvasController : MonoBehaviour
{
    public static MaxCanvasController i;

    [SerializeField] MaxBarController maxBar_original;

    public MaxBarController MaxBar
    {
        get
        {
            float max = maxBars[0].Value;
            MaxBarController maxBar_max = maxBars[0];
            for (int i = 1; i < maxBars.Count; i++)
            {
                if (maxBars[i].Value > max)
                {
                    max = maxBars[i].Value;
                    maxBar_max = maxBars[i];
                }
            }
            return maxBar_max;
        }
    }

    public int MaxBarNumber
    {
        get
        {
            float max = maxBars[0].Value;
            int num = 0;
            for (int i = 1; i < maxBars.Count; i++)
            {
                if (maxBars[i].Value > max)
                {
                    max = maxBars[i].Value;
                    num = i;
                }
            }
            return num;
        }
    }

    List<MaxBarController> maxBars = new List<MaxBarController>();
    bool showBars = true;
    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!CanvasManager.i.showMaxBars) return;
        MakeBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanvasManager.i.showMaxBars) return;
        ChangeBarLength();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void MakeBar()
    {
        if (BarCanvasController.i.displayMode == DisplayMode.Full)
        {
            for (int i = 0; i < (int)BarCanvasController.i.barCount; i++)
            {
                MaxBarController bar_clone = Instantiate(maxBar_original);
                bar_clone.Initialize(transform, i, -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / (float)BarCanvasController.i.barCount);
                maxBars.Add(bar_clone);
            }
        }
        else
        {
            for (int i = 0; i < BarCanvasController.i.LimitedBarCount; i++)
            {
                MaxBarController bar_clone = Instantiate(maxBar_original);
                bar_clone.Initialize(transform, i, -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / BarCanvasController.i.LimitedBarCount);
                maxBars.Add(bar_clone);
            }
        }
    }

    void ChangeBarLength()
    {
        for (int i = 0; i < maxBars.Count; i++)
        {
            maxBars[i].ChangeLength(InputSoundManager.i.spectrum[i]);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < maxBars.Count; i++)
        {
            maxBars[i].Reset();
        }
    }
}
