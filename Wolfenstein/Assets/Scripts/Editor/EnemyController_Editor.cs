using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyController))]
public class EnemyController_Editor : Editor
{
	private SerializedProperty m_EnemyData;
	private bool m_DisplayEnemyData;

	private void OnEnable()
	{
		m_EnemyData = serializedObject.FindProperty("m_EnemyData");
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		EditorGUILayout.Space();

		//DisplayEnemyData();
	}

	private void DisplayEnemyData()
	{
		EditorGUILayout.BeginVertical(GUI.skin.box);
		{
			EditorGUILayout.BeginHorizontal();
			{
				EditorGUI.indentLevel++;
				{
					m_DisplayEnemyData = EditorGUILayout.Foldout(m_DisplayEnemyData, /*"Enemy Data"*/""/*, GUILayout.Width(10.0f)*/);
					EditorGUILayout.LabelField("Enemy Data", EditorStyles.boldLabel);
				}
				EditorGUI.indentLevel--;
			}
			EditorGUILayout.EndHorizontal();

			if(m_DisplayEnemyData)
			{
				SerializedProperty hp = m_EnemyData.FindPropertyRelative("m_HP");
				Debug.Log("HP: " + hp);
				//EditorGUILayout.PropertyField(m_EnemyData.FindPropertyRelative("m_HP"));
				//EditorGUILayout.PropertyField(m_EnemyData.FindPropertyRelative("m_Speed"));
			}
		}
		EditorGUILayout.EndVertical();
	}
}
