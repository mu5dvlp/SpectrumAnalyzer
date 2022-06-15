using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckHzCanvasController : MonoBehaviour
{
    [SerializeField] Image checkHzBar_img;
    [SerializeField] TMP_Text checkHz_tmpText;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Move()
    {
        Vector2 pos = checkHzBar_img.transform.position;
        pos.x = Mathf.Clamp(Input.mousePosition.x, 50, Screen.width - 50);
        checkHzBar_img.transform.position = pos;

        pos.y = checkHz_tmpText.transform.position.y;
        checkHz_tmpText.transform.position = pos;

        float analyzeBarWidth = 0;
        if (BarCanvasController.i.displayMode == DisplayMode.Full) analyzeBarWidth = -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / (float)BarCanvasController.i.barCount;
        else analyzeBarWidth = -BarCanvasController.i.BarSpan + ((float)Screen.width - 100) / BarCanvasController.i.LimitedBarCount;
        int num = (int)((pos.x - 50) / (analyzeBarWidth + BarCanvasController.i.BarSpan));
        //Debug.Log($"analyzeBarWidth:{analyzeBarWidth}, num:{num}");

        checkHz_tmpText.text = $"{AudioSettings.outputSampleRate * num * 0.5f / 8192:F1}Hz";
    }
}
