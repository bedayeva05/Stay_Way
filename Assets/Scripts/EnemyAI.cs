using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    private PlayerController _player;
    public float viewAngle;
    public float damage = 30;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    public float doorDetectionRange = 1f;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
        DoorInteractionUpdate();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                // Placeholder for attack logic
                //Debug.Log("Attacking player");
            }
        }
    }

    private void NoticePlayerUpdate()
    {
        Vector3 direction = _player.transform.position - transform.position;
        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle / 2f) // Half the viewAngle for correct FOV check
        {
            float rayDistance = Vector3.Distance(transform.position, _player.transform.position); // Calculate distance to the player

            // Multiple ray origins at different heights for better detection
            Vector3[] rayOrigins = {
            transform.position + Vector3.up * 0.1f,
            transform.position + Vector3.up * 0.3f,
            transform.position + Vector3.up * 0.5f
        };

            RaycastHit hit; // Declare the RaycastHit variable once

            // Cast rays from different heights
            foreach (var origin in rayOrigins)
            {
                Debug.DrawRay(origin, direction, Color.red); // Visualize the raycast in the Scene view
                if (Physics.Raycast(origin, direction, out hit, rayDistance))
                {
                    if (hit.collider.gameObject == _player.gameObject)
                    {
                        _isPlayerNoticed = true;
                        //Debug.Log("Player detected by raycast from height: " + origin.y);
                        return; // Player noticed, exit the method
                    }
                }
            }

            // Sphere cast to detect the player with a broader range
            float sphereRadius = 0.5f; // Adjust based on player size
            Vector3 sphereCastOrigin = transform.position + Vector3.up * 1.0f; // Sphere cast origin height
            //Debug.DrawRay(sphereCastOrigin, direction, Color.green); // Visualize the sphere cast in the Scene view

            if (Physics.SphereCast(sphereCastOrigin, sphereRadius, direction, out hit, rayDistance))
            {
                if (hit.collider.gameObject == _player.gameObject)
                {
                    _isPlayerNoticed = true;
                    //Debug.Log("Player detected by sphere cast");
                }
            }
        }
    }
    private void DoorInteractionUpdate()
    {
        if (_navMeshAgent.remainingDistance <= doorDetectionRange)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, doorDetectionRange);
            foreach (var hitCollider in hitColliders)
            {
                Door door = hitCollider.GetComponent<Door>();
                if (door != null)
                {
                    door.ToggleDoor();
                    //Debug.Log("Opening door");
                    break; // Open the first detected door and break out of the loop
                }
            }
        }
    }


    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = _player.transform.position;
        }
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    private PlayerController _player;
    public float viewAngle;
    public float damage = 30;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        InitComponentLinks();
        PickNewPatrolPoint();
    }
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                
            }
        }
    }
    private void NoticePlayerUpdate()
    {
        var direction = _player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == _player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = _player.transform.position;
        }
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
}*/