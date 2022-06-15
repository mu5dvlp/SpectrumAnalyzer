using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataBarCanvasController : MonoBehaviour
{
    public static SaveDataBarCanvasController i;

    [SerializeField] SaveDataBarController saveDataBar_original;

    [Space(20)]
    [HideInInspector] public SaveDataMode saveDataMode = SaveDataMode.MasanoriMorise;

    public SaveDataBarController MaxBar
    {
        get
        {
            float max = saveDataBars[0].Value;
            SaveDataBarController saveDataBar_max = saveDataBars[0];
            for (int i = 1; i < saveDataBars.Count; i++)
            {
                if (saveDataBars[i].Value > max)
                {
                    max = saveDataBars[i].Value;
                    saveDataBar_max = saveDataBars[i];
                }
            }
            return saveDataBar_max;
        }
    }

    public int MaxBarNumber
    {
        get
        {
            float max = saveDataBars[0].Value;
            int num = 0;
            for (int i = 1; i < saveDataBars.Count; i++)
            {
                if (saveDataBars[i].Value > max)
                {
                    max = saveDataBars[i].Value;
                    num = i;
                }
            }
            return num;
        }
    }

    List<SaveDataBarController> saveDataBars = new List<SaveDataBarController>();
    bool showBars = true;
    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!CanvasManager.i.showSaveBars) return;
        MakeBar();
        LoadSaveData();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void MakeBar()
    {
        if (BarCanvasController.i.displayMode == DisplayMode.Full)
        {
            for (int i = 0; i < (int)BarCanvasController.i.barCount; i++)
            {
                SaveDataBarController bar_clone = Instantiate(saveDataBar_original);
                bar_clone.Initialize(transform, i, -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / (float)BarCanvasController.i.barCount);
                saveDataBars.Add(bar_clone);
            }
        }
        else
        {
            for (int i = 0; i < BarCanvasController.i.LimitedBarCount; i++)
            {
                SaveDataBarController bar_clone = Instantiate(saveDataBar_original);
                bar_clone.Initialize(transform, i, -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / BarCanvasController.i.LimitedBarCount);
                saveDataBars.Add(bar_clone);
            }
        }
    }

    public void LoadSaveData()
    {
        if (saveDataMode == SaveDataMode.Hina)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_Hina[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.Hina2)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_Hina2[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.Hina3)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_Hina3[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.Hina4)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_Hina4[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.Hina5)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_Hina5[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.Hina6)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_Hina6[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.SatoshiNakamura)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_SatoshiNakamura[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.MasanoriMorise)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_MasanoriMorise[i]);
            }
        }
        else if (saveDataMode == SaveDataMode.SunaoHashimoto)
        {
            for (int i = 0; i < saveDataBars.Count; i++)
            {
                saveDataBars[i].ChangeValue(SaveData.Instance.spectrum_SunaoHashimoto[i]);
            }
        }
        else
        {
            Debug.LogError($"FailedToLoad: Failed to load {saveDataMode} because the property {saveDataMode} does not exist.");
        }
    }
}
