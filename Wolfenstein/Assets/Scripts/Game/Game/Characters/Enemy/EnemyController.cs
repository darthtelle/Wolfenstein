using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	[SerializeField]
	private Enemy m_EnemyData;

	//private PlayerMovement m_Movement;
	private EnemyWeapon m_Weapon;
	private EnemyHealth m_Health;
	private EnemyAnimator m_Animator;

	private void Awake()
	{
		//m_Movement = gameObject.GetRequiredComponent<PlayerMovement>();
		m_Weapon = gameObject.GetRequiredComponent<EnemyWeapon>();
		m_Health = gameObject.GetRequiredComponent<EnemyHealth>();
		m_Animator = gameObject.GetRequiredComponent<EnemyAnimator>();
	}

	private void Start()
	{
		m_Weapon.Initialise(m_EnemyData.GetWeapon);
		m_Health.Initialise(m_EnemyData.GetHP);
	}








	/*[SerializeField]
	private Transform[] m_PatrolPointList;
	private int m_PatrolIndex;

	private NavMeshAgent m_Agent;

	private void Awake()
	{
		m_Agent = gameObject.GetRequiredComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if(m_Agent.remainingDistance < 0.5f)
		{
			NextPoint();
		}
	}

	private void NextPoint()
	{
		if(m_PatrolPointList.Length == 0)
		{
			return;
		}

		// Increment the patrol index.
		m_PatrolIndex = (m_PatrolIndex + 1) % m_PatrolPointList.Length;

		// Set the destination of the next patrol index position in the list.
		m_Agent.destination = m_PatrolPointList[m_PatrolIndex].position;
	}*/
}
