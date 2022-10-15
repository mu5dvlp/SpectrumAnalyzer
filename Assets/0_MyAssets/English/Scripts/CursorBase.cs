using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CursorBase : MonoBehaviour
{
    RectTransform rectTransform { get { return GetComponent<RectTransform>(); } }
    public Image cursor_img;
}

//ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
interface IMovable
{
    public void Move();
}

interface IRepositionable
{
    public void Reposition();
}
