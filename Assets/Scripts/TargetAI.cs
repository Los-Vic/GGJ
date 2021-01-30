using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAI : MonoBehaviour
{
    public float speed = 0.6f;
    private Animator animator;

    public int direction = 1;
    private float elapsed = 0;

    private float velocity = 0;
    private TargetViewCheck viewChecker;

    private bool startMoveFlag = false;
    public GM _gm;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        viewChecker = GetComponentInChildren<TargetViewCheck>();
    }
    private void Start()
    {
        TurnBody();
        velocity = speed;
    }
    // Update is called once per frame
    void Update()
    {
       if(startMoveFlag == false)
        {
            return;
        }
        elapsed += Time.deltaTime;

        transform.Translate(Vector3.forward * Time.deltaTime * velocity, Space.Self);
        animator.SetFloat("walkSpeed", Mathf.Abs(velocity));
    }
    public void StartWalk()
    {
        startMoveFlag = true;
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
        if (other.tag == "PlayerTrigger")
        {
            
            var pt = other.GetComponent<PlayerTrigger>();

            if(pt.turnBody)
            {
                direction = -direction;
                TurnBody();
            }
            velocity = pt.newVelocity;
            pt.StartCrowd();
            Destroy(other.gameObject);

        }
        else if(other.tag == "Finish")
        {
            _gm.GameSuccess();
        }
    }
}
