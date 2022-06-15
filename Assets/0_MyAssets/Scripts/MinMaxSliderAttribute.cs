using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;

#endif

public class MinMaxSliderAttribute : PropertyAttribute
{
    public float minLimit;
    public float maxLimit;

    public MinMaxSliderAttribute(float _min, float _max)
    {
        minLimit = _min;
        maxLimit = _max;
    }
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(MinMaxSliderAttribute))]
public class MinMaxSliderDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.Vector2) return;

        float minVal = property.vector2Value.x;
        float maxVal = property.vector2Value.y;

        var minMaxSliderAttribute = (MinMaxSliderAttribute)attribute;

        Rect posMin = position;
        posMin.x = 18;
        posMin.width = 50;

        Rect posSlider = position;
        posSlider.x = posMin.x + posMin.width;
        posSlider.width = position.width - 100;

        Rect posMax = position;
        posMax.x = posSlider.x + posSlider.width;
        posMax.width = 50;

        EditorGUI.LabelField(posMin, $"{property.vector2Value.x:F2}");
        EditorGUI.MinMaxSlider(posSlider, ref minVal, ref maxVal, minMaxSliderAttribute.minLimit, minMaxSliderAttribute.maxLimit);
        EditorGUI.LabelField(posMax, $"{property.vector2Value.y:F2}");

        property.vector2Value = new Vector2(minVal, maxVal);
    }
}
#endif