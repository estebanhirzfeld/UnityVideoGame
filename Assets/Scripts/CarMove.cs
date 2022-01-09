using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = destination.transform.position;
    }


}
