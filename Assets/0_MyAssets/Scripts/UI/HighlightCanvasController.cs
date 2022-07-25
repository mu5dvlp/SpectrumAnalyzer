using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighlightCanvasController : MonoBehaviour
{
    [SerializeField] Image realtimeHighlightBar_img;
    [SerializeField] TMP_Text realtimeHighlightHz_tmpText;

    [Space(20)]
    [Header("リアルタイム 測定範囲")]
    [MinMaxSlider(0, 1)][SerializeField] Vector2 range_realtime = new Vector2(0, 1);


    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Update()
    {
        Move_realtimeHighlightBar();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Move_realtimeHighlightBar()
    {
        if (BarCanvasController.i.MaxBar.Value < range_realtime.x || range_realtime.y < BarCanvasController.i.MaxBar.Value) return;

        Vector2 pos = realtimeHighlightBar_img.transform.position;
        pos.x = BarCanvasController.i.MaxBar.transform.position.x;
        realtimeHighlightBar_img.transform.position = pos;

        pos.y = realtimeHighlightHz_tmpText.transform.position.y;
        realtimeHighlightHz_tmpText.transform.position = pos;
        realtimeHighlightHz_tmpText.text = $"{AudioSettings.outputSampleRate * BarCanvasController.i.MaxBarNumber * 0.5f / 8192:F1}Hz";
    }

}
