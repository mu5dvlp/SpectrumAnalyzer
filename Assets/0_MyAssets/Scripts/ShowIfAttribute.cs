using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ShowIfAttribute : PropertyAttribute
{
    public bool condition;

    public ShowIfAttribute(bool _condition)
    {
        condition = _condition;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIfAttribute = (ShowIfAttribute)attribute;
        if (showIfAttribute.condition) return;

        base.OnGUI(position, property, label);
    }
}
#endif