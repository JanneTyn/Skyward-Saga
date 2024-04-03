    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChange : MonoBehaviour
{
    [SerializeField] Material skybox;

    [SerializeField] Light dirLight;
    [SerializeField] float dayTemp;
    [SerializeField] float nightTemp;
    [SerializeField] float dayBrightness;
    [SerializeField] float nightBrightness;
    [SerializeField] float dayShadowStr;
    [SerializeField] float nightShadowStr;
    [SerializeField] Vector3 dayRot;
    [SerializeField] Vector3 nightRot;

    [SerializeField] GameObject fireflyParent;
    [SerializeField] GameObject lightShaftParent;
    ParticleSystem[] fireflies;
    ParticleSystem[] lightShafts;

    [SerializeField] Color dayFog;
    [SerializeField] Color nightFog;

    private void Start()
    {
        skybox.SetFloat("_blendValue", 0);

        fireflies = fireflyParent.GetComponentsInChildren<ParticleSystem>();
        lightShafts = lightShaftParent.GetComponentsInChildren<ParticleSystem>();
    }

    public void SkyBoxDayNightChange(bool sunActivated)
    {
        if (!sunActivated)
        {
            StopCoroutine(changeOverTime(0, dayTemp, dayBrightness, dayShadowStr, dayRot, 1));
            StartCoroutine(changeOverTime(1, nightTemp, nightBrightness, nightShadowStr, nightRot, 1));
        }
        else if (sunActivated)
        {
            StopCoroutine(changeOverTime(1, nightTemp, nightBrightness, nightShadowStr, nightRot, 1));
            StartCoroutine(changeOverTime(0, dayTemp, dayBrightness, dayShadowStr, dayRot, 1));
        }
    }

    private IEnumerator changeOverTime(float targetBlend, float temperature, float brightness, float shadow, Vector3 targetRot, float duration)
    {
        float blendValue = skybox.GetFloat("_blendValue");
        /*float startTemp = dirLight.colorTemperature;
        float startBrightness = dirLight.intensity;
        float startShadow = dirLight.shadowStrength;
        Vector3 rot = transform.rotation.eulerAngles;*/

        for (float t = 0; t < duration; t += duration * Time.deltaTime)
        {
            skybox.SetFloat("_blendValue", Mathf.Lerp(blendValue, targetBlend, t));

            yield return null;
        }
    }
}
