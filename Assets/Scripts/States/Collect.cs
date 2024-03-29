using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();

    }

    void Start() => UpdateCount();
    
    void OnEnable() => Collectables.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectables.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();

    }

    void UpdateCount()
    {
        text.text = $"{count} / {Collectables.total}";
    }
}
