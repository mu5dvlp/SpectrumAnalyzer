using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighlightCanvasController : MonoBehaviour
{
    [SerializeField] Image realtimeHighlightBar_img;
    [SerializeField] Image averageHighlightBar_img;
    [SerializeField] Image saveDataHighlightBar_img;
    [SerializeField] Image maxHighlightBar_img;
    [SerializeField] TMP_Text realtimeHighlightHz_tmpText;
    [SerializeField] TMP_Text averageHighlightHz_tmpText;
    [SerializeField] TMP_Text saveDataHighlightHz_tmpText;
    [SerializeField] TMP_Text maxHighlightHz_tmpText;

    [Space(20)]
    [Header("リアルタイム 測定範囲")]
    [MinMaxSlider(0, 1)][SerializeField] Vector2 range_realtime = new Vector2(0, 1);
    [Header("平均値 測定範囲")]
    [MinMaxSlider(0, 1)][SerializeField] Vector2 range_average = new Vector2(0, 1);
    [Header("最大値 測定範囲")]
    [MinMaxSlider(0, 1)][SerializeField] Vector2 range_max = new Vector2(0, 1);


    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"{AudioSettings.outputSampleRate}Hz");
    }

    // Update is called once per frame
    void Update()
    {
        Move_realtimeHighlightBar();
        Move_averageHighlightBar();
        Move_saveDataHighlightBar();
        Move_maxHighlightBar();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Move_realtimeHighlightBar()
    {
        if (BarCanvasController.i.MaxBar.Value < range_realtime.x || range_average.y < BarCanvasController.i.MaxBar.Value) return;

        Vector2 pos = realtimeHighlightBar_img.transform.position;
        pos.x = BarCanvasController.i.MaxBar.transform.position.x;
        realtimeHighlightBar_img.transform.position = pos;

        pos.y = realtimeHighlightHz_tmpText.transform.position.y;
        realtimeHighlightHz_tmpText.transform.position = pos;
        realtimeHighlightHz_tmpText.text = $"{AudioSettings.outputSampleRate * BarCanvasController.i.MaxBarNumber * 0.5f / 8192:F1}Hz";
    }

    void Move_averageHighlightBar()
    {
        if (!CanvasManager.i.showAverageCanvas) return;
        if (AverageCanvasController.i.MaxBar.Value < range_average.x || range_average.y < AverageCanvasController.i.MaxBar.Value) return;

        Vector2 pos = averageHighlightBar_img.transform.position;
        pos.x = AverageCanvasController.i.MaxBar.transform.position.x;
        averageHighlightBar_img.transform.position = pos;

        pos.y = averageHighlightHz_tmpText.transform.position.y;
        averageHighlightHz_tmpText.transform.position = pos;
        averageHighlightHz_tmpText.text = $"{AudioSettings.outputSampleRate * AverageCanvasController.i.MaxBarNumber * 0.5f / 8192:F1}Hz";
    }

    void Move_saveDataHighlightBar()
    {
        if (!CanvasManager.i.showSaveBars) return;
        if (SaveDataBarCanvasController.i.MaxBar.Value < range_average.x || range_average.y < SaveDataBarCanvasController.i.MaxBar.Value) return;

        Vector2 pos = saveDataHighlightBar_img.transform.position;
        pos.x = SaveDataBarCanvasController.i.MaxBar.transform.position.x;
        saveDataHighlightBar_img.transform.position = pos;

        pos.y = saveDataHighlightHz_tmpText.transform.position.y;
        saveDataHighlightHz_tmpText.transform.position = pos;
        saveDataHighlightHz_tmpText.text = $"{AudioSettings.outputSampleRate * SaveDataBarCanvasController.i.MaxBarNumber * 0.5f / 8192:F1}Hz";

    }

    void Move_maxHighlightBar()
    {
        if (!CanvasManager.i.showMaxBars) return;
        if (MaxCanvasController.i.MaxBar.Value < range_average.x || range_average.y < MaxCanvasController.i.MaxBar.Value) return;

        Vector2 pos = maxHighlightBar_img.transform.position;
        pos.x = MaxCanvasController.i.MaxBar.transform.position.x;
        maxHighlightBar_img.transform.position = pos;

        pos.y = maxHighlightHz_tmpText.transform.position.y;
        maxHighlightHz_tmpText.transform.position = pos;
        maxHighlightHz_tmpText.text = $"{AudioSettings.outputSampleRate * MaxCanvasController.i.MaxBarNumber * 0.5f / 8192:F1}Hz";
    }
}
