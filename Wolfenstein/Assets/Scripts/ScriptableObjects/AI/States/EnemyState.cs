using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : ScriptableObject
{
	[SerializeField]
	private Transition[] m_Transitions;

	public virtual void StartState(EnemyStateController enemy) {}
	public virtual void FinishState(EnemyStateController enemy) {}

	protected abstract void UpdateStateLogic(EnemyStateController enemy);

	private EnemyState CheckTransitions(EnemyStateController enemy)
	{
		// Find player.
		PlayerController player = (PlayerController)enemy.GetData<PlayerController>(StateData.Player); //GameObject.FindGameObjectWithTag(Tags.Player).GetRequiredComponent<PlayerController>();

		for(int transitionIndex = 0; transitionIndex < m_Transitions.Length; transitionIndex++)
		{
			EnemyState nextState;

			if(m_Transitions[transitionIndex].CheckTransition(enemy, player))
			{
				nextState = m_Transitions[transitionIndex].GetTrueState;
			}
			else
			{
				nextState = m_Transitions[transitionIndex].GetFalseState;
			}

			if(nextState != null)
			{
				return nextState;
			}
		}

		return null;
	}

	public void UpdateState(EnemyStateController enemy, EnemyStateController.StateCallback stateCallback)
	{
		UpdateStateLogic(enemy);

		// Check whether the state can transition to the next state.
		EnemyState nextState = CheckTransitions(enemy);

		if((stateCallback != null) && (nextState != null))
		{
			stateCallback(nextState);
		}
	}
}

public static class StateData
{
	public static string Player = "Player";
	public static string PatrolIndex = "PatrolIndex";
}
