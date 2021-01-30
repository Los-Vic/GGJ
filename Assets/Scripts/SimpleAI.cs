using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public float speed = 0.6f;
    private Animator animator;

    public int direction = 1;
    private float elapsed = 0;

    private float velocity = 0;
    public bool willChangeDic = false;

    public bool startMove = false;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

    }
    private void Start()
    {
        TurnBody();
        velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove == false)
            return;

        elapsed += Time.deltaTime;

        TurnBody();


        transform.Translate(Vector3.forward * Time.deltaTime * velocity,Space.Self);
        animator.SetFloat("walkSpeed", Mathf.Abs(velocity));
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPCTrigger" && willChangeDic)
        {
            willChangeDic = false;
            direction = -direction;
            TurnBody();
        }
    }
    public void StartMove()
    {
        startMove = true;
    }
}
