using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetViewCheck : MonoBehaviour
{
   
    public bool isInCameraView = false;
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        isInCameraView = render.isVisible;
    }

    private void Update()
    {
        isInCameraView = render.isVisible;
       // print(isInCameraView.ToString());
    }
  
}
