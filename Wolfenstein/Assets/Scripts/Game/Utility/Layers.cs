using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers
{
	public static string Player = "Player";
	public static string Enemy = "Enemy";

	public static int GetLayer(string layerString)
	{
		return (LayerMask.NameToLayer(layerString));
	}

	public static int GetLayerMask(string layerString)
	{
		return (1 << LayerMask.NameToLayer(layerString));
	}
}
