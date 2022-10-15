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

    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void BeginMove()
    {
        pos_moveStart = transform.position;
    }

    //<interface Methods>ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void Reposition()
    {

    }

    public void Move()
    {
        if (!InputManager.i.isTouching) return;
        transform.position = pos_moveStart + InputManager.i.DifferenceFromTouchStart;
    }
}
