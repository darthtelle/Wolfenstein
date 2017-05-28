using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MaterialAnimator
{
	[SerializeField]
	private AnimData m_Idle;

	[SerializeField]
	private AnimData m_Shot;

	[SerializeField]
	private AnimData m_Death;

#region Animations

	public void TriggerShot()
	{
		ClearQueue();
		PlayAnimation(m_Shot);
		QueueAnimation(m_Idle);
	}

	public void TriggerDeath()
	{
		ClearQueue();
		QueueAnimation(m_Death);
	}

#endregion
}
