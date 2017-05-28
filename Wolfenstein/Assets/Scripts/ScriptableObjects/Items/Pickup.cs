using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : ScriptableObject
{
	public abstract void OnPickup(GameObject thisObject, Collider otherCollider);
}