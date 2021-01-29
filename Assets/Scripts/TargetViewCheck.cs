using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetViewCheck : MonoBehaviour
{
    [HideInInspector]
    public bool isInCameraView = false;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        isInCameraView = render.isVisible;
    }
}
