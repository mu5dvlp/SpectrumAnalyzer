using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum SaveDataMode
{
    [InspectorName("ヒナ")] Hina,
    [InspectorName("ヒナ2")] Hina2,
    [InspectorName("ヒナ3")] Hina3,
    [InspectorName("ヒナ4")] Hina4,
    [InspectorName("ヒナ5")] Hina5,
    [InspectorName("ヒナ6")] Hina6,
    [InspectorName("中村先生")] SatoshiNakamura,
    [InspectorName("森瀬先生")] MasanoriMorise,
    [InspectorName("橋本先生")] SunaoHashimoto,
    [InspectorName("自由")] Free
}
public class MenuCanvasController : MonoBehaviour
{
    public static MenuCanvasController i;
    [SerializeField] TMP_Dropdown saveShowMode_tmpDropdown;
    [SerializeField] TMP_Dropdown saveDataMode_tmpDropdown;

    [Space(20)]
    [HideInInspector] public SaveDataMode saveDataMode = SaveDataMode.Hina;
    [HideInInspector] public SaveDataMode saveShowMode = SaveDataMode.Hina;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
    }

    void Start()
    {
        saveDataMode_tmpDropdown.value = (int)saveDataMode;
        saveShowMode_tmpDropdown.value = (int)saveShowMode;
    }

    void OnValidate()
    {
        saveDataMode_tmpDropdown.options.Clear();
        saveShowMode_tmpDropdown.options.Clear();
        foreach (SaveDataMode mode in Enum.GetValues(typeof(SaveDataMode)))
        {
            saveDataMode_tmpDropdown.options.Add(new TMP_Dropdown.OptionData { text = $"{mode}" });
            saveShowMode_tmpDropdown.options.Add(new TMP_Dropdown.OptionData { text = $"{mode}" });
        }
        saveDataMode_tmpDropdown.value = (int)saveDataMode;
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void OnDropdownChange_SaveShow()
    {
        saveShowMode = (SaveDataMode)Enum.ToObject(typeof(SaveDataMode), saveShowMode_tmpDropdown.value);
    }

    public void OnBtnPush_SaveShow()
    {
        SaveDataBarCanvasController.i.saveDataMode = saveShowMode;
        SaveDataBarCanvasController.i.LoadSaveData();
    }

    public void OnDropdownChange_SaveDataMode()
    {
        saveDataMode = (SaveDataMode)Enum.ToObject(typeof(SaveDataMode), saveDataMode_tmpDropdown.value);
    }

    public void OnBtnPush_Save()
    {
        if (saveDataMode == SaveDataMode.Hina)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_Hina[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.Hina2)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_Hina2[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.Hina3)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_Hina3[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.Hina4)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_Hina4[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.Hina5)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_Hina5[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.Hina6)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_Hina6[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.SatoshiNakamura)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_SatoshiNakamura[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.MasanoriMorise)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_MasanoriMorise[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.SunaoHashimoto)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_SunaoHashimoto[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else if (saveDataMode == SaveDataMode.Free)
        {
            for (int i = 0; i < AverageCanvasController.i.averageBars.Count; i++)
            {
                SaveData.Instance.spectrum_Free[i] = AverageCanvasController.i.averageBars[i].Value;
            }
        }
        else
        {
            Debug.LogError($"FailedToSave: Failed to save {saveDataMode} because the property {saveDataMode} does not exist.");
        }

        SaveData.Instance.Save();
    }

    public void OnBtnPush_Clear(){
        AverageCanvasController.i.Reset();
    }
}
