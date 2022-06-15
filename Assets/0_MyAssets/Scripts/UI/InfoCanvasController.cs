using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoCanvasController : MonoBehaviour
{
    [SerializeField] TMP_Text totalAmout_tmpTxt;

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    // Update is called once per frame
    void Update()
    {
        totalAmout_tmpTxt.text = $"Total:{BarCanvasController.i.BarSum:F4}";
    }
}
