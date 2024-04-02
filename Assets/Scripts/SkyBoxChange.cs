    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChange : MonoBehaviour
{
    [SerializeField] Material skybox;
    [SerializeField] Color dayLight;
    [SerializeField] Color nightLight;
    [SerializeField] Light directionalLight;

    private void Start()
    {
        skybox.SetFloat("_blendValue", 0);
    }

    public void SkyBoxDayNightChange(bool sunActivated)
    {
        if (!sunActivated)
        {
            StartCoroutine(changeOverTime(1, 1));
        }
        else
            StartCoroutine(changeOverTime(0, 1));
    }

    private IEnumerator changeOverTime(float targetBlend, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime / duration)
        {
            float blendValue = skybox.GetFloat("_blendValue");

            skybox.SetFloat("_blendValue", Mathf.Lerp(blendValue, targetBlend, t));

            yield return null;
        }
    }
}
