using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterHealth : MonoBehaviour
{
	protected int m_MaxHealth;
	protected int m_HealthCount;

	public virtual void Initialise(int maxHealth)
	{
		m_MaxHealth = maxHealth;
		m_HealthCount = maxHealth;
	}

	public virtual void AdjustHealth(int health)
	{
		m_HealthCount = Mathf.Max(0, Mathf.Min(m_HealthCount + health, m_MaxHealth));

		Debug.Log(gameObject.name + ": Health: " + m_HealthCount);
	}
}
