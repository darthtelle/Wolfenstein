using UnityEngine;
using UnityEngine.UI;

public class Player_GameUI : MonoBehaviour
{
	[SerializeField]
	private Image m_PlayerImage;

	private Animator m_Animator;

	private void Awake()
	{
		m_Animator = m_PlayerImage.gameObject.GetRequiredComponent<Animator>();
	}

	private void OnEnable()
	{
		GameEventManager.Instance.AddListener<int>(GameEventManager.UI.UpdateHealth, UpdateHealth);
	}

	private void OnDisable()
	{
		GameEventManager.Instance.RemoveListener<int>(GameEventManager.UI.UpdateHealth, UpdateHealth);
	}

	private void UpdateHealth(int healthCount)
	{
		if(healthCount > 80)
		{
			 m_Animator.SetTrigger("Health1");
		}
		else if(healthCount > 60)
		{
			m_Animator.SetTrigger("Health2");
		}
		else if(healthCount > 40)
		{
			m_Animator.SetTrigger("Health3");
		}
		else if(healthCount > 20)
		{
			m_Animator.SetTrigger("Health4");
		}
		else if(healthCount > 10)
		{
			m_Animator.SetTrigger("Health5");
		}
		else
		{
			m_Animator.SetTrigger("Health6");
		}
	}
}
