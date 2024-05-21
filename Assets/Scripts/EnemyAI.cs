using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints; // List of points for patrolling
    public float viewAngle;              // View angle to notice the player
    public float damage = 30f;           // Damage dealt to the player

    private NavMeshAgent _navMeshAgent;  // NavMeshAgent for navigation
    private PlayerController _player;    // Reference to the player
    private bool _isPlayerNoticed;       // Flag to check if the player is noticed

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    }

    // Initialize component links
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //_playerHealth = _player.GetComponent<PlayerHealth>(); // Uncomment if using PlayerHealth
    }

    // Handle the attack behavior
    private void AttackUpdate()
    {
        if (_isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            //_playerHealth.DealDamage(damage * Time.deltaTime); // Uncomment if using PlayerHealth
        }
    }

    // Check if the player is within the field of view
    private void NoticePlayerUpdate()
    {
        Vector3 direction = _player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            Vector3 rayOrigin = transform.position + Vector3.up * 0.3f;
            Debug.Log(_isPlayerNoticed);
            if (Physics.Raycast(rayOrigin, direction, out hit))
            {
                Debug.DrawRay(rayOrigin, direction, Color.red);
                if (hit.collider.gameObject == _player.gameObject)
                { 
                    _isPlayerNoticed = true;
                }
                Debug.Log(_isPlayerNoticed);
            }
        }
    }

    // Pick a random patrol point
    private void PickNewPatrolPoint()
    {
        if (patrolPoints.Count > 0)
        {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
    }

    // Handle the chase behavior
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = _player.transform.position;
        }
    }

    // Handle the patrol behavior
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            PickNewPatrolPoint();
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
    //private PlayerHealth _playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    // Update is called once per frame
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
        //_playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                //_playerHealth.DealDamage(damage * Time.deltaTime);
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