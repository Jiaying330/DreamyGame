using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncColor : AudioSyncer
{
    MeshRenderer cubeMeshRenderer;
    public Color beatColor;
    public Color restColor;

    void Start() {
        cubeMeshRenderer = GetComponent<MeshRenderer>();
    }

    private IEnumerator ChangeToColor(Color target)
    {
        Color curr = cubeMeshRenderer.material.color;
        Color initial = curr;
        float timer = 0;
        
        while (curr != target)
        {
            curr = Color.Lerp(initial, target, timer / timeToBeat);
            timer += Time.deltaTime;

            cubeMeshRenderer.material.color = curr;
            yield return null;
        }
        isBeat = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (isBeat) return;

        cubeMeshRenderer.material.color = Color.Lerp(cubeMeshRenderer.material.color, restColor, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();
        StopCoroutine("MoveToScChangeToColorale");
        StartCoroutine("ChangeToColor", beatColor);
    }
}
