using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : EventManager
{
	private static GameEventManager s_Instance;
	public static GameEventManager Instance
	{
		get
		{
			if(s_Instance == null)
			{
				s_Instance = new GameEventManager();
			}

			return s_Instance;
		}
	}

	public enum UI
	{
		UpdateAmmo,
		UpdateWeapon,
		UpdateHealth,
		UpdateLives,
		UpdateScore,
	};
}
