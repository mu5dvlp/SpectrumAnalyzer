using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBase : MonoBehaviour
{
    float m_circleRadius = 75;
}

//ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
interface IRepositionable
{
    public void Reposition();
}

interface IMovable
{
    public void Move();
}