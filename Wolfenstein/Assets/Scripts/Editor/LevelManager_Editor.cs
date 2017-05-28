using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelManager))]
public class LevelManager_Editor : Editor
{
	private Texture2D m_LevelTexture;
	private PrefabDataList m_PrefabData;

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		EditorGUILayout.BeginVertical("box");
		{
			EditorGUILayout.BeginHorizontal();
			{
				EditorGUILayout.LabelField("Prefab", GUILayout.Width(40.0f));
				m_PrefabData = (PrefabDataList)EditorGUILayout.ObjectField(m_PrefabData, typeof(PrefabDataList), false);
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			{
				EditorGUILayout.LabelField("Level", GUILayout.Width(40.0f));
				m_LevelTexture = (Texture2D)EditorGUILayout.ObjectField(m_LevelTexture, typeof(Texture2D), false);
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			{
				if(GUILayout.Button("Generate Level"))
				{
					((LevelManager)target).GenerateLevel(m_LevelTexture, m_PrefabData);
				}
				else if(GUILayout.Button("Reset Level"))
				{
					((LevelManager)target).ResetLevel();
				}
			}
			EditorGUILayout.EndHorizontal();
		}
		EditorGUILayout.EndVertical();
	}
}
