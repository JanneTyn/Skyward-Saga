using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeMaterial01 : MonoBehaviour
{
    public Material glow;
    public Material dark;

    public GameObject Object;
    void Start()
    {

        var renderer = Object.GetComponent<MeshRenderer>();
        Material[] materials = renderer.sharedMaterials; 
        materials[1] = dark;
        renderer.sharedMaterials = materials;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var renderer = Object.GetComponent<MeshRenderer>();
            Material[] materials = renderer.sharedMaterials; 
            materials[1] = glow;
            renderer.sharedMaterials = materials;
        }
       

        }
            
    }
        
        
    

