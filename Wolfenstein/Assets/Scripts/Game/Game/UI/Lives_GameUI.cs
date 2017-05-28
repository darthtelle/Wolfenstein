using UnityEngine;
using UnityEngine.UI;

public class Lives_GameUI : MonoBehaviour
{
	[SerializeField]
	private Text m_LivesText;

	private void OnEnable()
	{
		GameEventManager.Instance.AddListener<int>(GameEventManager.UI.UpdateLives, UpdateLives);
	}

	private void OnDisable()
	{
		GameEventManager.Instance.RemoveListener<int>(GameEventManager.UI.UpdateLives, UpdateLives);
	}

	private void UpdateLives(int livesCount)
	{
		m_LivesText.text = livesCount.ToString();
	}
}
