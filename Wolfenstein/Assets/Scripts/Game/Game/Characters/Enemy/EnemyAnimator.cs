using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MaterialAnimator
{
	[SerializeField]
	private AnimData m_Idle;

	[SerializeField]
	private AnimData m_WalkForward;

	[SerializeField]
	private AnimData m_Attack;

	[SerializeField]
	private AnimData m_Shot;

	[SerializeField]
	private AnimData m_Death;

#region Animations

	public void WalkForward()
	{
		ClearQueue();
		PlayAnimation(m_WalkForward);
		QueueAnimation(m_Idle);
	}

	public void Attack()
	{
		ClearQueue();
		PlayAnimation(m_Attack);
		QueueAnimation(m_Idle);
	}

	public void Shot()
	{
		ClearQueue();
		PlayAnimation(m_Shot);
		QueueAnimation(m_Idle);
	}

	public void Death()
	{
		ClearQueue();
		QueueAnimation(m_Death);
	}

#endregion
}
