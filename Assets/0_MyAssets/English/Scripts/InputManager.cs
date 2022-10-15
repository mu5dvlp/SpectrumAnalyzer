using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager _inputManager;
    public static InputManager i
    {
        get
        {
            if (_inputManager == null) _inputManager = GameObject.FindObjectOfType(typeof(InputManager)) as InputManager;
            return _inputManager;
        }
    }

    [SerializeField] RealCursor realCursor;

    [HideInInspector] public bool isTouching = false;
    Vector2 pos_touchStart;
    public Vector2 DifferenceFromTouchStart
    {
        get
        {
            return (Vector2)Input.mousePosition - pos_touchStart;
        }
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        _inputManager = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void OnPointerDownEvent()
    {
        isTouching = true;
        pos_touchStart = Input.mousePosition;

        realCursor.BeginMove();
    }

    public void OnPointerUpEvent()
    {
        isTouching = false;
    }
}
