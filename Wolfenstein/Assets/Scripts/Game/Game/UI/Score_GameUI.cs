using UnityEngine;
using UnityEngine.UI;

public class Score_GameUI : MonoBehaviour
{
	[SerializeField]
	private Text m_ScoreText;

	private void OnEnable()
	{
		GameEventManager.Instance.AddListener<int>(GameEventManager.UI.UpdateScore, UpdateScore);
	}

	private void OnDisable()
	{
		GameEventManager.Instance.RemoveListener<int>(GameEventManager.UI.UpdateScore, UpdateScore);
	}

	private void UpdateScore(int scoreCount)
	{
		m_ScoreText.text = scoreCount.ToString();
	}
}
