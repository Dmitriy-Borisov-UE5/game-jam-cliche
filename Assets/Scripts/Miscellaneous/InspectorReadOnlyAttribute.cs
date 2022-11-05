using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class InspectorReadOnlyAttribute : PropertyAttribute {

}

[CustomPropertyDrawer(typeof(InspectorReadOnlyAttribute))]
public class InspectorReadOnlyDrawer : PropertyDrawer {

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

        Color color = GUI.backgroundColor;

        GUI.enabled = false;

        if (property.type == "string")
            if (property.stringValue == "-- INVALID --")
                GUI.backgroundColor = Color.red;

        EditorGUI.PropertyField(position, property, label, true);
        GUI.backgroundColor = color;
        GUI.enabled = true;
    }
}
