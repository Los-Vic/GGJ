using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public float newVelocity;
    public bool turnBody;

    public SimpleAI[] crowd;

    public void StartCrowd()
    {
        foreach(var ai in crowd)
        {
            ai.StartMove();
        }
    }

}
