using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityCanvasController : MonoBehaviour
{
    public static VelocityCanvasController i;

    [SerializeField] Image velocityBar_img;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Move()
    {
        velocityBar_img.rectTransform.position = new Vector2(Screen.width / 2, 50 + (Screen.height - 100) * InputSoundManager.i.GetVelocity());
    }
}
