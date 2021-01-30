using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetViewCheck : MonoBehaviour
{
   
    public bool isInCameraView = false;
    private Renderer render;
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        render = GetComponent<Renderer>();
        isInCameraView = CustomIsVisible();
        
    }

    private void Update()
    {
        isInCameraView = CustomIsVisible();
       
        //print(isInCameraView.ToString());
    }
   private bool CustomIsVisible()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);

        if (GeometryUtility.TestPlanesAABB(planes, boxCollider.bounds))
            return true;
        else
            return false;
    }
}
