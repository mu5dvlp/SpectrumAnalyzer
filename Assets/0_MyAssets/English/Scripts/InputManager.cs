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

    //ーーーーーーーーーーーーーーーーーーーーー
    [SerializeField] RealCursor realCursor;

    [Space(10)]
    [SerializeField] float moveDistanceThreshold = 0.1f;

    //ーーーーーーーーーーーーーーーーーーーーー
    [HideInInspector] public bool isTouching = false;
    public bool IsMoving
    {
        get
        {
            if (!isTouching) return false;

            float distance = Vector2.Distance((Vector2)Input.mousePosition, pos_previous);
            if (distance > moveDistanceThreshold) return true;
            else return false;
        }
    }

    Vector2 pos_touchStart;
    Vector2 pos_previous;
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

    void LateUpdate()
    {
        pos_previous = Input.mousePosition;
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
        pos_touchStart = Input.mousePosition;
    }
}
