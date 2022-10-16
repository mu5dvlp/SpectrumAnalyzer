using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugCanvas : MonoBehaviour
{
    public static DebugCanvas _debugCanvas;
    public static DebugCanvas i
    {
        get
        {
            if (_debugCanvas == null) _debugCanvas = GameObject.FindObjectOfType(typeof(DebugCanvas)) as DebugCanvas;
            return _debugCanvas;
        }
    }

    [SerializeField] GameObject debugContainer;
    [SerializeField] Transform userDataContainer_transform;
    [SerializeField] UserDataListElement userDataListElement_original;

    bool[] isBtnPushed_array = { false, false, false, false };
    float startTime_sec;
    float finishTime_sec;
    bool finishExperiment = false;
    [HideInInspector] public float FoundTimeSec { get { return finishTime_sec - startTime_sec; } }
    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Start()
    {
        debugContainer.SetActive(false);
        Init_DataList();
    }

    void Update()
    {
#if UNITY_EDITOR
        // isBtnPushed_array[0] = Input.GetKey(KeyCode.Alpha1);
        // isBtnPushed_array[1] = Input.GetKey(KeyCode.Alpha2);
        // isBtnPushed_array[2] = Input.GetKey(KeyCode.Alpha3);
        // isBtnPushed_array[3] = Input.GetKey(KeyCode.Alpha4);
        // CheckOpenDebug();
#endif
    }

    //<OnBtn>ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void OnBtnPush(int num)
    {
        isBtnPushed_array[num] = true;
        CheckOpenDebug();
    }

    public void CheckOpenDebug()
    {
        foreach (var condition in isBtnPushed_array)
        {
            if (!condition) return;
        }

        debugContainer.SetActive(true);
    }

    public void OnBtnRelease(int num)
    {
        isBtnPushed_array[num] = false;
    }

    public void OnBtnPush_debug_close()
    {
        debugContainer.SetActive(false);
    }

    public void OnBtnPush_debug_restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnBtnPush_debug_addData(bool correct)
    {
        EnglishReportData data = new EnglishReportData()
        {
            uid = MU5Editor.MU5Utility.GenerateUID(),
            time_sec = FoundTimeSec,
            answer = correct
        };

        CreateDataElement(data);

        SaveData.Instance.englishReportDatas.Add(data);
        SaveData.Instance.Save();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Init_DataList()
    {
        foreach (var data in SaveData.Instance.englishReportDatas)
        {
            CreateDataElement(data);
        }
    }

    void CreateDataElement(EnglishReportData data)
    {
        var userDataListElement_clone = Instantiate(userDataListElement_original);
        userDataListElement_clone.Initialize(userDataContainer_transform, data);
    }

    public void StartTimer()
    {
        startTime_sec = Time.time;
    }

    public void StopTimer()
    {
        if (finishExperiment) return;
        finishTime_sec = Time.time;
        finishExperiment = true;
    }

    [ContextMenu("ClearEnglishReportData")]
    public void ClearEnglishReportData()
    {
        SaveData.Instance.englishReportDatas.Clear();
        SaveData.Instance.Save();
    }
}

[System.Serializable]
public class EnglishReportData
{
    public string uid;
    public float time_sec;
    public bool answer;
}