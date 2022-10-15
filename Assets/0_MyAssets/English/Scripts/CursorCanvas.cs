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

    [Space(20)]
    [SerializeField] float openAnswerTime_sec = 0.5f;
    [SerializeField] int necessaryOpenAnswerTapCount = 3;

    public float region_minX { get { return mask.rectTransform.position.x - mask.rectTransform.sizeDelta.x / 2; } }
    public float region_minY { get { return mask.rectTransform.position.y - mask.rectTransform.sizeDelta.y / 2; } }
    public float region_maxX { get { return mask.rectTransform.position.x + mask.rectTransform.sizeDelta.x / 2; } }
    public float region_maxY { get { return mask.rectTransform.position.y + mask.rectTransform.sizeDelta.y / 2; } }

    [Space(20)]
    public RealCursor realCursor;
    public List<DummyCursor> dummyCursors = new List<DummyCursor>();

    float tapStartTime_sec;
    bool wasStartedTap = false;
    int tapCount = 0;
    bool isOpened = false;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        _cursorCanvas = this;
    }

    void Start()
    {
        realCursor.transform.position = GetRandomCursorPosition();
        foreach (var dummyCursor in dummyCursors)
        {
            dummyCursor.transform.position = GetRandomCursorPosition();
        }
    }

    void Update()
    {
        TapTimeUpdate();
        CheckOpenAnswer();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    Vector2 GetRandomCursorPosition()
    {
        Vector2 pos = new Vector2();
        pos.x = Random.Range(region_minX - realCursor.cursor_img.rectTransform.sizeDelta.x / 2, region_maxX + realCursor.cursor_img.rectTransform.sizeDelta.x / 2);
        pos.y = Random.Range(region_minY - realCursor.cursor_img.rectTransform.sizeDelta.y / 2, region_maxY + realCursor.cursor_img.rectTransform.sizeDelta.y / 2);
        return pos;
    }

    public void OnPointerDownEvent()
    {
        wasStartedTap = true;
        tapCount++;
        CheckOpenAnswer();
    }

    void TapTimeUpdate()
    {
        if (wasStartedTap) return;

        tapStartTime_sec = Time.time;
    }

    void CheckOpenAnswer()
    {
        if (Time.time - tapStartTime_sec < openAnswerTime_sec)
        {
            if (tapCount != necessaryOpenAnswerTapCount) return;

            ChangeDummyCursorVisible();
            DebugCanvas.i.StopTimer();
            ResetTapCount();
        }
        else ResetTapCount();
    }

    void ChangeDummyCursorVisible()
    {
        foreach (var dummyCursor in dummyCursors)
        {
            dummyCursor.gameObject.SetActive(!dummyCursor.gameObject.activeSelf);
        }
    }

    void ResetTapCount()
    {
        tapStartTime_sec = Time.time;
        tapCount = 0;
        wasStartedTap = false;
    }
}
