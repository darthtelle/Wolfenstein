using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
	private const string k_ShotTrigger = "Shot";
	private const string k_DeadBool = "Dead";

	private EnemyAnimator m_Animator;

	private void Awake()
	{
		m_Animator = gameObject.GetRequiredComponent<EnemyAnimator>();
	}

	public override void AdjustHealth(int health)
	{
		base.AdjustHealth(health);

		if(m_HealthCount <= 0)
		{
			m_Animator.Death();
		}
		else
		{
			m_Animator.Shot();
		}
	}
}