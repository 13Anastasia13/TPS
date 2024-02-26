using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    private bool _isPlayerNoticed;
    public float viewAngle;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPetrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if(Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }

        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }

        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPetrolPoint();
            }
        }
    }

    private void PickNewPetrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}