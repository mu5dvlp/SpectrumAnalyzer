using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserDataListElement : MonoBehaviour
{
    [SerializeField] TMP_Text uid_tmpTxt;
    [SerializeField] TMP_Text timeSec_tmpTxt;
    [SerializeField] TMP_Text answer_tmpTxt;

    [HideInInspector] public string uid;
    [HideInInspector] public float time_sec;
    [HideInInspector] public bool answer;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void Initialize(Transform _parent, EnglishReportData data)
    {
        transform.SetParent(_parent);
        SetData(data);
    }

    public void SetData(EnglishReportData data)
    {
        uid = data.uid;
        uid_tmpTxt.text = $"UID: {uid}";

        time_sec = data.time_sec;
        timeSec_tmpTxt.text = $"Time_sec: {time_sec}";

        answer = data.answer;
        answer_tmpTxt.text = $"O/X: {answer}";
    }
}
