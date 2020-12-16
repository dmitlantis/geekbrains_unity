using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum EnemyState
{
    Walk,
    Attack
}
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> waypoints;
    public float agroDistance = 10;
    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    private int m_CurrentWaypoint;
    private EnemyState m_State;
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.SetDestination(waypoints[0].position);
        m_State = EnemyState.Walk;
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = (transform.position - player.position).magnitude;
        if (m_State == EnemyState.Walk)
        {
            if (m_Agent.remainingDistance < m_Agent.stoppingDistance)
            {
                m_CurrentWaypoint = (m_CurrentWaypoint + 1) % waypoints.Count;
                m_Agent.SetDestination(waypoints[m_CurrentWaypoint].position);
            }

            if (distance < agroDistance)
            {
                m_State = EnemyState.Attack;
            }
        }

        if (m_State == EnemyState.Attack)
        {
            if (distance > agroDistance)
            {
                m_State = EnemyState.Walk;
                m_Agent.SetDestination(waypoints[m_CurrentWaypoint].position);
            }
            else
            {
                m_Agent.SetDestination(player.position);
            }
        }
        
        if (distance <= m_Agent.stoppingDistance)
        {
            m_Animator.SetBool("attack",true);
        }
        else
        {
            m_Animator.SetBool("attack",false);
        }
    }
}
