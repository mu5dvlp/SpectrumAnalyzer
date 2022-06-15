using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AverageBarController : MonoBehaviour
{
    RectTransform rectTransform;
    Image bar_img;
    List<float> data = new List<float>();

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

    void Update()
    {
        ChangeLength();
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
        //if(num==0)Debug.Log($"{_size.x}");
    }

    public void AddData(float _value, float _sum)
    {
        data.Add(_value * _sum);
    }

    void ChangeLength()
    {
        bar_img.fillAmount = GetAverageData() * AverageCanvasController.i.averageBarMaginification;
    }

    float GetAverageData()
    {
        if (data.Count == 0) return 0;

        float sum = 0;
        for (int i = 0; i < data.Count; i++)
        {
            sum += data[i];
        }
        return sum / data.Count;
    }

    public void ResetData()
    {
        bar_img.fillAmount = 0;
        data.Clear();
    }
}
