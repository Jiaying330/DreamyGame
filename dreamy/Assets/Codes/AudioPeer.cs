using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    // AudioSource audioSource;
    public float[] samples;
    public static float spectrumValue {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        samples = new float[128];
        // Au.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    void GetSpectrumAudioSource()
    {
        AudioListener.GetSpectrumData(samples, 0, FFTWindow.Hamming);
        if (samples != null && samples.Length > 0)
        {
            spectrumValue = samples[0] * 100;
        }
    }
}
