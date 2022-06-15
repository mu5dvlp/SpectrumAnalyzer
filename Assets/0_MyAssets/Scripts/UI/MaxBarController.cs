using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxBarController : MonoBehaviour
{
    RectTransform rectTransform;
    Image bar_img;

    public float Value
    {
        get { return bar_img.fillAmount; }
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        bar_img = GetComponent<Image>();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void Initialize(Transform _parent, int num, float _width)
    {
        transform.SetParent(_parent);

        rectTransform.position = new Vector2(50 + num * (_width + BarCanvasController.i.BarSpan), 50);

        Vector2 _size = rectTransform.sizeDelta;
        _size.x = _width;
        _size.y = Screen.height - 100;
        rectTransform.sizeDelta = _size;

        bar_img.fillAmount = 0;
    }

    public void ChangeLength(float num)
    {
        if (num < bar_img.fillAmount) return;
        bar_img.fillAmount = num;
    }

    public void Reset()
    {
        bar_img.fillAmount = 0;
    }
}
