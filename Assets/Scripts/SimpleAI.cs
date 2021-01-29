using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public float speed = 1.0f;
    private Animator animator;

    private float holdTime = 1.5f;
    public int direction = 1;
    private float elapsed = 0;

    private float velocity = 0;
    private TargetViewCheck viewChecker;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        viewChecker = GetComponentInChildren<TargetViewCheck>();
    }
    private void Start()
    {
        TurnBody();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        RandomDirection();

        TurnBody();

        if (transform.position.x >= SimpleCameraController.limitMax & velocity > 0)
        {
            direction = -direction;
            velocity = -velocity;

        }
        if (transform.position.x <= SimpleCameraController.limitMin & velocity < 0)
        {
            direction = -direction;
            velocity = -velocity;
        }


        transform.Translate(Vector3.right * Time.deltaTime * velocity,Space.World);
        animator.SetFloat("walkSpeed", Mathf.Abs(velocity));
    }

    void RandomDirection()
    {
        if(elapsed > holdTime)
        {
            if (Random.value < 0.4f)
            {
                direction = -direction;
                elapsed = 0;
                velocity = direction * speed;
            }
            else if(Random.value < 0.8f)
            {
                elapsed = 0;
                velocity = direction * speed;
            }
            else
            { 
                //Í£ÔÚÔ­µØ
                elapsed = 0;
                velocity = 0;
                
            }
            
        }
    }
    void TurnBody()
    {
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
