using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{
	[SerializeField]
	private Decision[] m_Decisions;
	public Decision[] GetDecisions { get { return m_Decisions; } }

	[SerializeField]
	private EnemyState m_True;
	public EnemyState GetTrueState { get { return m_True; } }

	[SerializeField]
	private EnemyState m_False;
	public EnemyState GetFalseState { get { return m_False; } }

	public bool CheckTransition(EnemyStateController enemy, PlayerController player)
	{
		// For this transition to return true, all the decisions in the list must return true (&& relationship).
		for(int decisionIndex = 0; decisionIndex < m_Decisions.Length; decisionIndex++)
		{
			if(m_Decisions[decisionIndex].Decide(enemy, player) == false)
			{	
				// Decision failed, transition can not be transitioned.
				return false;
			}
		}

		// All the decisions were successful! Transition is a-go!
		return true;
	}
}
