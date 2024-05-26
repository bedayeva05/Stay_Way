using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
	public List<Transform> patrolPoints;
	public float viewAngle = 120f;
	public float doorDetectionRange = 1f;
	public float attackCooldown = 2f;
	public Animator animator;

	private PlayerController _player;
	private NavMeshAgent _navMeshAgent;
	private bool _isPlayerNoticed;
	private int _currentPatrolIndex;
	private float _lastAttackTime;

	void Start()
	{
		_player = FindObjectOfType<PlayerController>();
		InitComponentLinks();
		PickNewPatrolPoint();
		_lastAttackTime = -attackCooldown;
	}

	void Update()
	{
		NoticePlayerUpdate();
		ChaseUpdate();
		AttackUpdate();
		PatrolUpdate();
		DoorInteractionUpdate();
		RotateTowardsMovementDirection();
		UpdateAnimation();
	}

	private void InitComponentLinks()
	{
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}

	private void AttackUpdate()
	{
		if (_isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
		{
			if (Time.time >= _lastAttackTime + attackCooldown)
			{
				_player.GetComponent<PlayerHealth>().MakeDamage();
				_lastAttackTime = Time.time;
			}
		}
	}

	private void NoticePlayerUpdate()
	{
		Vector3 direction = _player.transform.position - transform.position;
		_isPlayerNoticed = false;

		if (Vector3.Angle(transform.forward, direction) < viewAngle)
		{
			float rayDistance = Vector3.Distance(transform.position, _player.transform.position);
			Vector3[] rayOrigins = {
				transform.position + Vector3.up * 0.1f,
				transform.position + Vector3.up * 0.3f,
				transform.position + Vector3.up * 0.5f
			};

			RaycastHit hit;
			foreach (var origin in rayOrigins)
			{
				//Debug.DrawRay(origin, direction, Color.red);
				if (Physics.Raycast(origin, direction, out hit, rayDistance) && hit.collider.gameObject == _player.gameObject)
				{
					_isPlayerNoticed = true;
					// Debug.Log("Player detected by raycast from height: " + origin.y);
					return;
				}
			}
		}
	}

	private void DoorInteractionUpdate()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, doorDetectionRange);
		foreach (var hitCollider in hitColliders)
		{
			Door door = hitCollider.GetComponent<Door>();
			if (door != null)
			{
				door.ToggleDoor();
				//Debug.Log("Opening door");
				break;
			}
		}
	}

	private void PickNewPatrolPoint()
	{
		if (patrolPoints.Count == 0) return;
		_navMeshAgent.destination = patrolPoints[_currentPatrolIndex].position;
		_currentPatrolIndex = (_currentPatrolIndex + 1) % patrolPoints.Count;
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
		if (!_isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
		{
			PickNewPatrolPoint();
		}
	}

	private void RotateTowardsMovementDirection()
	{
		Vector3 velocity = _navMeshAgent.velocity;
		if (velocity.sqrMagnitude > Mathf.Epsilon) // Check if the agent is moving
		{
			Quaternion targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _navMeshAgent.angularSpeed);
		}
	}
	private void UpdateAnimation()
	{
		bool isWalking = _navMeshAgent.velocity.sqrMagnitude > Mathf.Epsilon;
		animator.SetBool("Walk", isWalking);
	}
}
