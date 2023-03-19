using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private List<Renderer> _rendererList;

    public void SetMaterial(Material material) 
    {
        foreach (var renderer in _rendererList)
            renderer.material = material;
    }
}
