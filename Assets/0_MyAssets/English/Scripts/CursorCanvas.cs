using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorCanvas : MonoBehaviour
{
    public static CursorCanvas _cursorCanvas;
    public static CursorCanvas i
    {
        get
        {
            if (_cursorCanvas == null) _cursorCanvas = GameObject.FindObjectOfType(typeof(CursorCanvas)) as CursorCanvas;
            return _cursorCanvas;
        }
    }
    //ーーーーーーーーーーーーーーーーーーーーー
    [SerializeField] RectMask2D mask;
    [SerializeField] AnimationClip anim;

    public float region_minX { get { return mask.rectTransform.position.x - mask.rectTransform.sizeDelta.x / 2; } }
    public float region_minY { get { return mask.rectTransform.position.y - mask.rectTransform.sizeDelta.y / 2; } }
    public float region_maxX { get { return mask.rectTransform.position.x + mask.rectTransform.sizeDelta.x / 2; } }
    public float region_maxY { get { return mask.rectTransform.position.y + mask.rectTransform.sizeDelta.y / 2; } }

    List<DummyCursor> dummyCursors = new List<DummyCursor>();

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        _cursorCanvas = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    [ContextMenu("test")]
    public void Test()
    {
        // Debug.Log($"{region_minX}, {region_minY}, {region_maxX}, {region_maxY}");

    }
}
