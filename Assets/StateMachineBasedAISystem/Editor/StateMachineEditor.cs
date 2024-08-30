using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EmirhanDur.AISystem
{
    [CustomEditor(typeof(StateMachine<>), true)]
    public class StateMachineEditor : Editor
    {
        private SerializedProperty initialState;
        private SerializedProperty currentState;
        private SerializedProperty transitions;

        private void OnEnable()
        {
            initialState = serializedObject.FindProperty("initialState");
            currentState = serializedObject.FindProperty("currentState");
            transitions = serializedObject.FindProperty("transitions");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("State Machine Settings", EditorStyles.boldLabel);

            // Initial State
            EditorGUILayout.PropertyField(initialState, new GUIContent("Initial State"));

            // Current State (Read-Only)
            EditorGUILayout.LabelField("Current State", currentState.objectReferenceValue != null ? currentState.objectReferenceValue.name : "None");

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Transitions", EditorStyles.boldLabel);

            // Display Transitions
            for (int i = 0; i < transitions.arraySize; i++)
            {
                SerializedProperty transition = transitions.GetArrayElementAtIndex(i);
                SerializedProperty fromState = transition.FindPropertyRelative("fromState");
                SerializedProperty condition = transition.FindPropertyRelative("condition");
                SerializedProperty targetState = transition.FindPropertyRelative("targetState");

                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.PropertyField(fromState, new GUIContent("From State"));
                EditorGUILayout.PropertyField(condition, new GUIContent("Condition"));
                EditorGUILayout.PropertyField(targetState, new GUIContent("Target State"));
                EditorGUILayout.EndVertical();

                EditorGUILayout.Space();
            }

            // Add/Remove Transition Buttons
            if (GUILayout.Button("Add Transition", GUILayout.Height(30)))
            {
                transitions.InsertArrayElementAtIndex(transitions.arraySize);
            }

            if (GUILayout.Button("Remove Last Transition", GUILayout.Height(30)))
            {
                if (transitions.arraySize > 0)
                {
                    transitions.DeleteArrayElementAtIndex(transitions.arraySize - 1);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
