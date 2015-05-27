// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the Health extension for Unity. Licensed under the MIT
// license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace HealthEx.HealthComponent {

    [CustomEditor(typeof (Health))]
    [CanEditMultipleObjects]
    public sealed class HealthEditor : Editor {
        #region FIELDS

        private Health Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty healthUpdatedCallback;
        private SerializedProperty healthValue;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawHealthValueField();
            DrawHealthUpdatedCallback();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable() {
            Script = (Health) target;

            description = serializedObject.FindProperty("description");
            healthValue = serializedObject.FindProperty("healthValue");
            healthUpdatedCallback =
                serializedObject.FindProperty("healthUpdatedCallback");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        private void DrawHealthUpdatedCallback() {
            EditorGUILayout.PropertyField(
                healthUpdatedCallback,
                new GUIContent(
                    "Health Changed Callback",
                    "Callback executed on health value change."));
        }

        private void DrawHealthValueField() {
            EditorGUILayout.PropertyField(
                healthValue,
                new GUIContent(
                    "Health",
                    "Health value."));
        }

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    Health.Version,
                    Health.Extension));
        }

        #endregion INSPECTOR CONTROLS

        #region METHODS

        [MenuItem("Component/Health/Health")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof (Health));
            }
        }

        #endregion METHODS
    }

}