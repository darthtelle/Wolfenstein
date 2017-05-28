using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
	public override void Initialise(int maxHealth)
	{
		base.Initialise(maxHealth);

		GameEventManager.Instance.Trigger(GameEventManager.UI.UpdateHealth, m_HealthCount);
	}

	public override void AdjustHealth(int health)
	{
		base.AdjustHealth(health);

		GameEventManager.Instance.Trigger(GameEventManager.UI.UpdateHealth, m_HealthCount);
	}

#if UNITY_EDITOR
	private void Update()
	{
		if(Input.GetKey(KeyCode.T))
		{
			AdjustHealth(-1);
		}
		else if(Input.GetKey(KeyCode.Y))
		{
			AdjustHealth(1);
		}
	}
#endif
}
