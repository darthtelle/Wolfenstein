using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
	[SerializeField]
	private Pickup m_Pickup;

	private void Awake()
	{
		if(m_Pickup == null)
		{
			Debug.LogError("ERROR: " + gameObject + " does not have pickup data.", gameObject);
		}
	}

	private void OnTriggerEnter(Collider otherCollider)
	{
		m_Pickup.OnPickup(gameObject, otherCollider);
	}
}
