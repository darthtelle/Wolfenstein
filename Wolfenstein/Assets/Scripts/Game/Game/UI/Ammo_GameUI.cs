using UnityEngine;
using UnityEngine.UI;

public class Ammo_GameUI : MonoBehaviour
{
	[SerializeField]
	private Text m_CountText;

	private void OnEnable()
	{
		GameEventManager.Instance.AddListener<int>(GameEventManager.UI.UpdateAmmo, UpdateAmmoCount);
	}

	private void OnDisable()
	{
		GameEventManager.Instance.RemoveListener<int>(GameEventManager.UI.UpdateAmmo, UpdateAmmoCount);
	}

	private void UpdateAmmoCount(int ammoCount)
	{
		m_CountText.text = ammoCount.ToString();
	}
}
