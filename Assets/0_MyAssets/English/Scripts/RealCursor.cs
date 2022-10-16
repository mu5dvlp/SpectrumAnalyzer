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
        if (transform.position.x + cursor_img.rectTransform.sizeDelta.x / 2 < 0)
        {
            Vector2 pos = transform.position;
            pos.x = Screen.width + cursor_img.rectTransform.sizeDelta.x / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
        if (transform.position.y + cursor_img.rectTransform.sizeDelta.y / 2 < Screen.height - Screen.width)
        {
            Vector2 pos = transform.position;
            pos.y = Screen.height + cursor_img.rectTransform.sizeDelta.y / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
        if (transform.position.x - cursor_img.rectTransform.sizeDelta.x / 2 > Screen.width)
        {
            Vector2 pos = transform.position;
            pos.x = -cursor_img.rectTransform.sizeDelta.x / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
        if (transform.position.y - cursor_img.rectTransform.sizeDelta.y / 2 > Screen.height)
        {
            Vector2 pos = transform.position;
            pos.y = Screen.height - Screen.width - cursor_img.rectTransform.sizeDelta.y / 2;
            transform.position = pos;
            InputManager.i.OnPointerDownEvent();
        }
    }
}
