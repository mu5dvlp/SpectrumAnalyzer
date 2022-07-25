using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnalyzeMode
{
    [InspectorName("なし")] None,
    [InspectorName("マイク入力")] Microphone,
    [InspectorName("音源再生")] Audio
}
public class InputSoundManager : MonoBehaviour
{
    public static InputSoundManager i;

    [Header("入力設定")]
    [SerializeField] AudioClip audioClip;

    [Space(10)]
    [SerializeField] AnalyzeMode analyzeMode = AnalyzeMode.Microphone;

    [Header("出力設定")]
    [Space(10)]
    [Header("ベロシティ")]
    [SerializeField, Range(0, 100)] float spectrumMagnification = 1;
    [Space(10)]
    [Header("表示範囲")]
    [SerializeField][MinMaxSlider(0, 1)] Vector2 range = new Vector2(0, 1);

    AudioSource audioSource;
    [HideInInspector] public float[] spectrum;


    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void Awake()
    {
        i = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (BarCanvasController.i.displayMode == DisplayMode.Full) spectrum = new float[(int)BarCanvasController.i.barCount];
        else if (BarCanvasController.i.displayMode == DisplayMode.Limit) spectrum = new float[8192];

        if (analyzeMode == AnalyzeMode.Microphone) audioSource.clip = Microphone.Start(null, true, 10, 44100);
        else if (analyzeMode == AnalyzeMode.Audio) audioSource.clip = audioClip;

        if (!(analyzeMode == AnalyzeMode.Audio && audioClip == null)) audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        MinMaxTrimming();
        ApplyVoiceEffect();

        BarCanvasController.i.ChangeBarLength(spectrum);
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    void MinMaxTrimming()
    {
        for (int i = 0; i < spectrum.Length; i++)
        {
            spectrum[i] *= spectrumMagnification;
            if (spectrum[i] < range.x) spectrum[i] = 0;
            else if (spectrum[i] > range.y)
            {
                Debug.LogWarning($"Cliped:{spectrum[i]}");
                spectrum[i] = range.y;
            }
        }
    }

    void ApplyVoiceEffect()
    {
        for (int i = 0; i < spectrum.Length || i < SaveDataBarCanvasController.i.saveDataBars.Count; i++)
        {
            //spectrum[i] = spectrum[i] * (1 - filterMix) + SaveDataBarCanvasController.i.saveDataBars[i].Value * filterMix;
        }
    }

    public float GetVelocity()
    {
        float max = spectrum[0];
        for (int i = 1; i < spectrum.Length; i++)
        {
            if (spectrum[i] < range.x) continue;
            else if (spectrum[i] > range.y) max = spectrum[i];

            if (spectrum[i] > max) max = spectrum[i];
        }
        return max;
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    IEnumerator DelayMethod(float delayTime_sec, Action action) { yield return new WaitForSeconds(delayTime_sec); action(); }
}
