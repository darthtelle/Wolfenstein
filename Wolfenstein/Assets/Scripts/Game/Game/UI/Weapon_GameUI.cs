using UnityEngine;
using UnityEngine.UI;

public class Weapon_GameUI : MonoBehaviour
{
	[SerializeField]
	private Image m_WeaponImage;

	private void OnEnable()
	{
		GameEventManager.Instance.AddListener<Weapon>(GameEventManager.UI.UpdateWeapon, UpdateCurrentWeapon);
	}

	private void OnDisable()
	{
		GameEventManager.Instance.RemoveListener<Weapon>(GameEventManager.UI.UpdateWeapon, UpdateCurrentWeapon);
	}

	private void UpdateCurrentWeapon(Weapon currentWeapon)
	{
		m_WeaponImage.sprite = currentWeapon.GetUISprite;
	}
}
