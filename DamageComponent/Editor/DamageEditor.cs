// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the Health extension for Unity. Licensed under the MIT
// license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace HealthEx.DamageComponent {

    [CustomEditor(typeof (Damage))]
    [CanEditMultipleObjects]
    public sealed class DamageEditor : Editor {
        #region FIELDS

        private Damage Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty damageValue;
        private SerializedProperty description;
        private SerializedProperty lookupType;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawLookupTypeDropdown();
            DrawDamageValueField();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (Damage) target;

            description = serializedObject.FindProperty("description");
            damageValue = serializedObject.FindProperty("damageValue");
            lookupType = serializedObject.FindProperty("lookupType");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawLookupTypeDropdown() {
            EditorGUILayout.PropertyField(
                lookupType,
                new GUIContent(
                    "Lookup Type",
                    "Defines where to look for the Health component."));
        }


        private void DrawDamageValueField() {
            EditorGUILayout.PropertyField(
                damageValue,
                new GUIContent(
                    "Damage",
                    "Damage value."));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    Damage.Version,
                    Damage.Extension));
        }

        #endregion INSPECTOR CONTROLS

        #region METHODS

        [MenuItem("Component/Health/Damage")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof (Damage));
            }
        }

        #endregion METHODS
    }

}