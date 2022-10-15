using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCursor : CursorBase, IRepositionable, IMovable
{
    Vector2 pos_moveStart;
    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Start()
    {

    }

    void Update()
    {
        Move();
        Reposition();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void BeginMove()
    {
        pos_moveStart = transform.position;
    }

    [ContextMenu("test")]
    public void Test()
    {
        // Debug.Log($"Transform world:{transform.position}, local:{transform.localPosition}");
        // Debug.Log($"RectTransform world:{cursor_img.rectTransform.position}, private:{cursor_img.rectTransform.localPosition}");
    }

    //<interface Methods>ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void Move()
    {
        if (!InputManager.i.isTouching) return;
        transform.position = pos_moveStart + InputManager.i.DifferenceFromTouchStart;
    }

    public void Reposition()
    {
        if (transform.position.x + cursor_img.rectTransform.sizeDelta.x / 2 < CursorCanvas.i.region_minX)
        {
            Vector2 pos = transform.position;
            pos.x = CursorCanvas.i.region_maxX + cursor_img.rectTransform.sizeDelta.x / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
        if (transform.position.y + cursor_img.rectTransform.sizeDelta.y / 2 < CursorCanvas.i.region_minY)
        {
            Vector2 pos = transform.position;
            pos.y = CursorCanvas.i.region_maxY + cursor_img.rectTransform.sizeDelta.y / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
        if (transform.position.x - cursor_img.rectTransform.sizeDelta.x / 2 > CursorCanvas.i.region_maxX)
        {
            Vector2 pos = transform.position;
            pos.x = CursorCanvas.i.region_minX - cursor_img.rectTransform.sizeDelta.x / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
        if (transform.position.y - cursor_img.rectTransform.sizeDelta.y / 2 > CursorCanvas.i.region_maxY)
        {
            Vector2 pos = transform.position;
            pos.y = CursorCanvas.i.region_minY - cursor_img.rectTransform.sizeDelta.y / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
    }
}
