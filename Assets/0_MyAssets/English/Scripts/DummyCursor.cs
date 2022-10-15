using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCursor : CursorBase, IRepositionable, IMovable
{
    Animator animator;
    [HideInInspector] public Vector2 direction;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {

    }
    void Start()
    {

    }

    void Update()
    {
        Move();
        Reposition();
    }

    //<interface Methods>ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void Reposition()
    {
        
    }

    public void Move()
    {
        if (!InputManager.i.IsMoving) return;
    }
}
