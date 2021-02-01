using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{

    [SerializeField] private bool _kill;
    [SerializeField] private bool _revive;
    
    
    private Rigidbody[] m_Rigidbodies;
    private Collider[] m_Colliders;

    private Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbodies = GetComponentsInChildren<Rigidbody>();
        m_Colliders = GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_kill)
        {
            Kill();
        }

        if (_revive)
        {
            Revive();
        }
    }

    public void Kill()
    {
        _kill = false;
        SetRagdollState(true);
    }

    public void Revive()
    {
        _revive = false;
        SetRagdollState(false);
    }

    private void SetRagdollState(bool active)
    {
        for (int i = 0; i < m_Rigidbodies.Length; i++)
        {
            m_Rigidbodies[i].isKinematic = !active;
        }

        for (int i = 0; i < m_Colliders.Length; i++)
        {
            m_Colliders[i].enabled = active;
        }

        m_Animator.enabled = !active;
        m_Rigidbodies[0].isKinematic = active;
        m_Colliders[0].enabled = !active;
    }
}
