using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer (typeof(IntVector2))]
public class IntVector2_PropertyDrawer : PropertyDrawer 
{
	private const float k_LabelWidth = 12.0f;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);

		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		float fieldWidth = (position.width - (k_LabelWidth * 2)) * 0.5f;

		Rect xLabelRect = new Rect(position.x, position.y, k_LabelWidth, position.height);
		Rect xRect = new Rect(xLabelRect.x + xLabelRect.width, position.y, fieldWidth, position.height);
		Rect yLabelRect = new Rect(xRect.x + xRect.width, position.y, k_LabelWidth, position.height);
		Rect yRect = new Rect(yLabelRect.x + yLabelRect.width, position.y, fieldWidth, position.height);

		EditorGUI.LabelField(xLabelRect, "X");
		EditorGUI.PropertyField(xRect, property.FindPropertyRelative("x"), GUIContent.none);
		EditorGUI.LabelField(yLabelRect, "Y");
		EditorGUI.PropertyField(yRect, property.FindPropertyRelative("y"), GUIContent.none);

		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
