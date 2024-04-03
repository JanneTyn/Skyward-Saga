    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChange : MonoBehaviour
{
    [SerializeField] Material skybox;
    [SerializeField] Color dayLight;
    [SerializeField] Color nightLight;
    [SerializeField] Light directionalLight;
    public float blend;

    private void Start()
    {
        skybox.SetFloat("_blendValue", 0);
    }
    private void Update()
    {
        blend = skybox.GetFloat("_blendValue");
    }

    public void SkyBoxDayNightChange(bool sunActivated)
    {
        if (!sunActivated)
        {
            StopCoroutine(changeOverTime(0, 1));
            StartCoroutine(changeOverTime(1, 1));
        }
        else if (sunActivated)
        {
            StopCoroutine(changeOverTime(1, 1));
            StartCoroutine(changeOverTime(0, 1));
        }
    }

    private IEnumerator changeOverTime(float targetBlend, float duration)
    {
        float blendValue = skybox.GetFloat("_blendValue");

        for (float t = 0; t < duration; t += duration * Time.deltaTime)
        {

            skybox.SetFloat("_blendValue", Mathf.Lerp(blendValue, targetBlend, t));

            yield return null;
        }
    }
}
