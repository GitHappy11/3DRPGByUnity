using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//自动添加相应的组件
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    public EnemyStates enemyStates;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        SwitchStates();
    }
    private void SwitchStates()
    {
        switch (enemyStates)
        {
            case EnemyStates.Guard:
                break;
            case EnemyStates.Patrol:
                break;
            case EnemyStates.Chase:
                break;
            case EnemyStates.Dead:
                break;
            default:
                break;
        }
    }
}

public enum EnemyStates
{
    Guard,
    Patrol,
    Chase,
    Dead
}
