using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
	protected const string k_FireTrigger = "Fire";
	protected const string k_FireState = "Fire";

	public delegate void FireCallback();

#region Display
	[Header("Display")]

	[SerializeField]
	protected Sprite m_UISprite;
	public Sprite GetUISprite { get { return m_UISprite; } }

	[SerializeField]
	protected Sprite m_GameSprite;
	public Sprite GetGameSprite { get { return m_GameSprite; } }

	[SerializeField]
	protected RuntimeAnimatorController m_AnimatorController;
	public RuntimeAnimatorController GetAnimatorController { get { return m_AnimatorController; } }

#endregion

#region Shooting
	[Header("Damage")]

	[SerializeField]
	private int m_Damage;

	[SerializeField]
	private int m_MaxDistance;

	[SerializeField]
	private bool m_HitScan;

#endregion

	public abstract void UpdateWeapon(PlayerWeapon playerWeapon, FireCallback fireCallback, FireCallback finishedFireCallback);

	protected void Fire(PlayerWeapon playerWeapon, FireCallback fireCallback, FireCallback finishedFireCallback)
	{
		// Check whether the animation is playing.
		if(playerWeapon.GetAnimator.IsPlaying(k_FireState) == false)
		{
			fireCallback();

			bool isHit = false;
			RaycastHit hit;
			isHit = Physics.Raycast(playerWeapon.gameObject.transform.position, playerWeapon.gameObject.transform.forward, out hit, m_MaxDistance, 1 << LayerMask.NameToLayer("Enemy"));

			// Trigger the fire animation.
			playerWeapon.GetAnimator.SetTrigger(playerWeapon, k_FireTrigger, new string[] { k_FireState }, 

				delegate
				{ 	
					if(isHit)
					{
						//Debug.Log("Hit: " + hit.collider.gameObject);

						int hitChance = DetermineHit(hit);
						int baseDamage = CalculateDamage(hit, hitChance);

						Debug.Log("Hit: " + hit.collider.gameObject + " Damage: " + baseDamage);

						hit.collider.gameObject.GetRequiredComponent<CharacterHealth>().AdjustHealth(-baseDamage);
					}

					// Notify the player the weapon has finished firing.
					finishedFireCallback();
				}
			);
		}
	}

	protected int DetermineHit(RaycastHit hit) 
	{
		int hitChance = 0;

		float distance = hit.distance;

		hitChance = 256 - Mathf.FloorToInt(distance * 16);

		return hitChance;
	}

	protected int CalculateDamage(RaycastHit hit, int hitChance)
	{
		int random = Random.Range(0, 255);

		if(m_HitScan)
		{
			// wolfenstein.wikia.com/wiki/Hitscan
			// Enemy shooting
			/*if(random < hitChance)
			{
				if(hit.distance < 2)
				{
					return Mathf.FloorToInt(random / 4);
				}
				else if((hit.distance >= 2) && (hit.distance <= 4))
				{
					return Mathf.FloorToInt(random / 8);
				}
				else if(hit.distance > 4)
				{
					return Mathf.FloorToInt(random / 16);
				}
			}*/

			if(hit.distance < 2)
			{
				return Mathf.FloorToInt(random / 4);
			}
			else if((hit.distance >= 2) && (hit.distance <= 4))
			{
				return Mathf.FloorToInt(random / 6);
			}
			else if((hit.distance > 4) && ((random / 12) < hit.distance))
			{
				return Mathf.FloorToInt(random / 6);
			}
		}
		else
		{
			return Mathf.FloorToInt(random / m_Damage);
		}

		return 0;
	}
}
