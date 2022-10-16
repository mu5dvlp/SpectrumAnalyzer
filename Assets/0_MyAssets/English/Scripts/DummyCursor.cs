using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCursor : CursorBase, IRepositionable, IMovable
{
    [SerializeField] Vector2 magnitude_range = new Vector2(10, 70);
    float magnitude = 50;

    Animator animator;
    [HideInInspector] public Vector2 direction;

    int number_hash = Animator.StringToHash("Number");
    int isMoving_hash = Animator.StringToHash("IsMoving");
    int offsetTimeSec_has = Animator.StringToHash("OffsetTimeSec");

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        magnitude = Random.Range(magnitude_range.x, magnitude_range.y);
        animator.SetFloat(offsetTimeSec_has, Random.Range(0f, 1f));
    }

    void Update()
    {
        Move();
        Reposition();
    }

    //<interface Methods>ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    public void Move()
    {
        if (!InputManager.i.IsMoving)
        {
            animator.SetBool(isMoving_hash, false);
            return;
        }
        else
        {
            animator.SetInteger(number_hash, (int)Random.Range(0, 4));
            animator.SetBool(isMoving_hash, true);
            transform.position += (Vector3)(direction * magnitude);
        }
    }

    public void Reposition()
    {
        if (transform.position.x + cursor_img.rectTransform.sizeDelta.x / 2 < 0)
        {
            Vector2 pos = transform.position;
            pos.x = CursorCanvas.i.region_maxX + cursor_img.rectTransform.sizeDelta.x / 2;
            transform.position = pos;
        }
        if (transform.position.y + cursor_img.rectTransform.sizeDelta.y / 2 < Screen.height - Screen.width)
        {
            Vector2 pos = transform.position;
            pos.y = CursorCanvas.i.region_maxY + cursor_img.rectTransform.sizeDelta.y / 2;
            transform.position = pos;
        }
        if (transform.position.x - cursor_img.rectTransform.sizeDelta.x / 2 > Screen.width)
        {
            Vector2 pos = transform.position;
            pos.x = CursorCanvas.i.region_minX - cursor_img.rectTransform.sizeDelta.x / 2;
            transform.position = pos;
        }
        if (transform.position.y - cursor_img.rectTransform.sizeDelta.y / 2 > Screen.height)
        {
            Vector2 pos = transform.position;
            pos.y = CursorCanvas.i.region_minY - cursor_img.rectTransform.sizeDelta.y / 2;
            transform.position = pos;
        }
    }
}
