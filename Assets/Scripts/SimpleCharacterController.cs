using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Animator animator;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var velocity = Mathf.Abs(Time.deltaTime * x * speed);
        if(x >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x >= SimpleCameraController.limitMax & speed > 0)
        {
            animator.SetFloat("walkSpeed", 0);
            return;
        }
        if (transform.position.x <= SimpleCameraController.limitMin & speed < 0)
        {
            animator.SetFloat("walkSpeed", 0);
            return;
        }

        transform.Translate(-1.0f * transform.forward * Time.deltaTime * x * speed);
        animator.SetFloat("walkSpeed", velocity);
    }
}
