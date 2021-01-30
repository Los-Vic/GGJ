using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{


    //jump
    public float duration = 1;
    public float v_x = 1;
    public float v_y = 1;
    private float a = 0;

    private bool inJump = false;
    public GM _gm;
    // Start is called before the first frame update
    void Start()
    {
        a = v_y / duration * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gm.isGaming)
            return;

        var x = Input.GetAxis("Horizontal");
           
        if (!inJump && Mathf.Abs(x) > 0.05f)
        {
            v_x = Mathf.Abs(v_x) * Mathf.Sign(x);
            StartCoroutine(Jump());
        }
 
    }
    
    IEnumerator Jump()
    {
        Vector3 startPos = transform.position;
        inJump = true;
        float t = 0;
        while( t < duration)
        {
            t = t + Time.deltaTime;
            var x = v_x * t;
            var y = v_y* t - 0.5f * a * t * t;
            transform.position = startPos + new Vector3(x, y, 0);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, 0.8f, -3.0f);
        inJump = false;
    }
}
