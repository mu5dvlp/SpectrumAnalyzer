using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInput : MonoBehaviour
{
    float[] spectrum;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioinput = GetComponent<AudioSource>();
        audioinput.clip = Microphone.Start(null, true, 10, 44100);
        audioinput.Play();
        spectrum = new float[256];
        //Debug.Log("マイク");
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        var maxIndex = 0;
        var maxValue = 0.0f;
        for (int i = 0; i < spectrum.Length; i++)
        {
            var val = spectrum[i] * 100;
            if (val > maxValue)
            {
                maxValue = val;
                maxIndex = i;
            }
        }
        var freq = maxIndex * AudioSettings.outputSampleRate / 2 / spectrum.Length;
        Debug.Log(freq);
    }
}