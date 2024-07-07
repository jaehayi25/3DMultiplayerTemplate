using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    // [SerializeField] private int colorId; 
    [SerializeField] private SkinnedMeshRenderer meshRenderer;

    private Material material;

    private void Awake()
    {
        material = new Material(meshRenderer.material);
        meshRenderer.material = material; 
    }

    public void SetPlayerColor(Color color)
    {
        material.color = color;
    }
}
