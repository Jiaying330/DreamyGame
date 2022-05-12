using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias; // what spectrum value triggers a beat
    public float timeStep; // minimum interval between beats
    public float timeToBeat;
    public float restSmoothTime;
    
    private float previousAudioValue;
    private float audioValue;
    private float timer;

    protected bool isBeat;

    public virtual void OnBeat()
    {
        Debug.Log("beat");
        timer = 0;
        isBeat = true;
    }

    // Update is called once per frame
    private void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        previousAudioValue = audioValue;
        audioValue = AudioPeer.spectrumValue;

        if(previousAudioValue > bias && audioValue <= bias) {
            if (timer > timeStep) OnBeat();
        }
        if (previousAudioValue <= bias && audioValue > bias) {
            if(timer > timeStep) OnBeat();
        }
        timer += Time.deltaTime;
    }
}
