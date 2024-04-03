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

    [SerializeField] Color dayFog;
    [SerializeField] Color nightFog;
    [SerializeField] float dayDensity;
    [SerializeField] float nightDensity;

    [SerializeField] Material fireflies;
    [SerializeField] Material lightShafts;

    private void Start()
    {
        skybox.SetFloat("_blendValue", 0);
    }

    public void SkyBoxDayNightChange(bool sunActivated)
    {
        if (!sunActivated)
        {
            StopCoroutine(changeOverTime(0, dayTemp, dayBrightness, dayShadowStr, dayRot, dayFog, dayDensity, 1));
            StartCoroutine(changeOverTime(1, nightTemp, nightBrightness, nightShadowStr, nightRot, nightFog, nightDensity, 1));
        }
        else if (sunActivated)
        {
            StopCoroutine(changeOverTime(1, nightTemp, nightBrightness, nightShadowStr, nightRot, nightFog, nightDensity, 1));
            StartCoroutine(changeOverTime(0, dayTemp, dayBrightness, dayShadowStr, dayRot, dayFog, dayDensity, 1));
        }
    }

    private IEnumerator changeOverTime(float targetBlend, float temperature, float brightness, float shadow, Vector3 targetRot, Color fog, float density, float duration)
    {
        float blendValue = skybox.GetFloat("_blendValue");
        float startTemp = dirLight.colorTemperature;
        float startBrightness = dirLight.intensity;
        float startShadow = dirLight.shadowStrength;
        Vector3 rot = dirLight.transform.rotation.eulerAngles;

        Color startFog = RenderSettings.fogColor;
        float startDensity = RenderSettings.fogDensity;

        Color color1 = fireflies.color;
        Color color2 = lightShafts.color;

        for (float t = 0; t < duration; t += duration * Time.deltaTime)
        {
            skybox.SetFloat("_blendValue", Mathf.Lerp(blendValue, targetBlend, t));

            dirLight.colorTemperature = Mathf.Lerp(startTemp, temperature, t);
            dirLight.intensity = Mathf.Lerp(startBrightness, brightness, t);
            dirLight.shadowStrength = Mathf.Lerp(startShadow, shadow, t);

            dirLight.gameObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(rot), Quaternion.Euler(targetRot), t);

            RenderSettings.fogColor = Color.Lerp(startFog, fog, t);
            RenderSettings.fogDensity = Mathf.Lerp(startDensity, density, t);

            fireflies.color = Color.Lerp(color1, new Color(color1.r, color1.g, color1.b, targetBlend), t);
            lightShafts.color = Color.Lerp(color2, new Color(color2.r, color2.g, color2.b, 1 - targetBlend), t);

            yield return null;
        }
    }
}
