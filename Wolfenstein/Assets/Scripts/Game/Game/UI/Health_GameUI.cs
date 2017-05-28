using UnityEngine;
using UnityEngine.UI;

public class Health_GameUI : MonoBehaviour
{
	[SerializeField]
	private Text m_HealthText;

	private void OnEnable()
	{
		GameEventManager.Instance.AddListener<int>(GameEventManager.UI.UpdateHealth, UpdateHealthCount);
	}

	private void OnDisable()
	{
		GameEventManager.Instance.RemoveListener<int>(GameEventManager.UI.UpdateHealth, UpdateHealthCount);
	}

	private void UpdateHealthCount(int healthCount)
	{
		m_HealthText.text = healthCount.ToString();
	}
}
