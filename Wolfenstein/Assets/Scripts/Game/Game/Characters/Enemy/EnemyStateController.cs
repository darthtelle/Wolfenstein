using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : MonoBehaviour
{
	[SerializeField]
	private EnemyState m_CurrentState;

#region Patrol Data
	[Header("Patrol Data")]

	[SerializeField]
	private GameObject[] m_PatrolList;
	public GameObject[] GetPatrolList { get { return m_PatrolList; } }

#endregion

	private EnemyController m_EnemyController;
	public EnemyController GetEnemyController { get { return m_EnemyController; } }

	private NavMeshAgent m_NavMeshAgent;
	public NavMeshAgent GetNavMeshAgent { get { return m_NavMeshAgent; } }

	private Dictionary<string, object> m_StateData;

	public delegate void StateCallback(EnemyState nextState);

	public void Initialise(EnemyController enemy)
	{
		m_StateData = new Dictionary<string, object>();

		m_EnemyController = enemy;

		// Find and store a reference to the the player.
		PlayerController player = GameObject.FindGameObjectWithTag(Tags.Player).GetRequiredComponent<PlayerController>();
		SetData(StateData.Player, player);

		m_NavMeshAgent = gameObject.GetRequiredComponent<NavMeshAgent>();
		m_NavMeshAgent.speed = m_EnemyController.GetData.GetSpeed;

		if(m_CurrentState != null)
		{
			m_CurrentState.StartState(this);
		}
	}

	public void UpdateState()
	{
		if(m_CurrentState != null)
		{
			m_CurrentState.UpdateState(this, ChangeState);
		}
	}

	private void ChangeState(EnemyState nextState)
	{
		// Check the next state is valid.
		if((nextState != m_CurrentState) && (nextState != null))
		{
			if(m_CurrentState != null)
			{
				// Finish the current state.
				m_CurrentState.FinishState(this);
			}

			Debug.Log("Next State: " + nextState);

			// Update the current state to the next state.
			m_CurrentState = nextState;

			if(m_CurrentState != null)
			{
				// Start the new state.
				m_CurrentState.StartState(this);
			}
		}
	}

	public T GetData<T>(string key)
	{
		if(m_StateData.ContainsKey(key))
		{
			return (T)m_StateData[key];
		}
		else
		{
			return default(T);
		}
	}

	public void SetData<T>(string key, T value)
	{
		if(m_StateData.ContainsKey(key) == false)
		{
			m_StateData.Add(key, value);
		}
		else
		{
			m_StateData[key] = value;
		}
	}
}
