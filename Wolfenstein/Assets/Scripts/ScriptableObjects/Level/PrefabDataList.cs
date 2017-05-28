using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/Prefab Data List")]
public class PrefabDataList : ScriptableObject
{
	[SerializeField]
	private PrefabData[] m_DataList;
	public PrefabData[] GetDataList { get { return m_DataList; } }
}

[System.Serializable]
public class PrefabData
{
	public LevelManager.ParentType m_Parent;
	public Color32 m_Colour;
	public GameObject m_Prefab;
}