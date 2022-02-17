using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrapBehaviour : MonoBehaviour
{
    enum TrapTypes {mine, turret, antiair, detect, stun, slow};
    [SerializeField]
    TrapTypes TrapType;
    public GameObject TrapTarget;
    public GameObject TrappedTarget;
    public bool fired;
    public float StunDuration, StunTimer;

    void Start()
    {
        fired = false;
        StunTimer = StunDuration;
    }
    void FixedUpdate()
    {
        if(StunDuration > StunTimer)
        {
            StunTimer += Time.deltaTime;
        }

        if(TrappedTarget!=null && fired && StunTimer >= StunDuration)
        {
            SlowTrapDeactivate(TrappedTarget);
        }
    }

    void StunTrapActivate(GameObject target)
    {
        if (target.CompareTag("Enemy") && fired==false) // If the object is an enemy
        {
            TrappedTarget = target;
            TrappedTarget.GetComponent<NavMeshAgent>().speed = 0f;
            fired = true;
            StunTimer = 0f;
        }
    }

    void SlowTrapActivate(GameObject target)
    {
        if (target.CompareTag("Enemy") && fired==false) // If the object is an enemy
        {
            TrappedTarget = target;
            TrappedTarget.GetComponent<NavMeshAgent>().speed = 1f;
        }
    }

    void SlowTrapDeactivate(GameObject target)
    {
        target.GetComponent<NavMeshAgent>().speed = 2.5f;
        TrappedTarget = null;
    }

    void OnTriggerEnter(Collider target)
    {
        TrapTarget = target.gameObject;

        Debug.Log("entered");

        switch(TrapType)
        {
            case TrapTypes.mine:

                break;
            case TrapTypes.turret:

                break;
            case TrapTypes.antiair:

                break;
            case TrapTypes.detect:

                break;
            case TrapTypes.stun:
                StunTrapActivate(TrapTarget);
                break;
            case TrapTypes.slow:
                SlowTrapActivate(TrapTarget);
                break;
        }  
    }

    void OnTriggerExit(Collider target)
    {
        Debug.Log("exited");

        if(target.gameObject == TrappedTarget)
        {
            switch(TrapType)
            {
                case TrapTypes.mine:

                    break;
                case TrapTypes.turret:

                    break;
                case TrapTypes.antiair:

                    break;
                case TrapTypes.detect:

                    break;
                case TrapTypes.stun:

                    break;
                case TrapTypes.slow:
                    SlowTrapDeactivate(TrappedTarget);
                    break;
            } 
        }
    }
}
