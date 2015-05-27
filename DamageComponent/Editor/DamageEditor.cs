using UnityEditor;
using UnityEngine;

namespace HealthEx.DamageComponent {

    [CustomEditor(typeof(Damage))]
    [CanEditMultipleObjects]
    public sealed class DamageEditor : Editor {
        #region FIELDS

        private Damage Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty damageValue;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawDamageValueField();

            serializedObject.ApplyModifiedProperties();
        }
        private void OnEnable() {
            Script = (Damage)target;

            description = serializedObject.FindProperty("description");
            damageValue = serializedObject.FindProperty("damageValue");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS
        private void DrawDamageValueField() {
            EditorGUILayout.PropertyField(
                damageValue,
                new GUIContent(
                    "Damage",
                    "Damage value."));
        }


        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    Damage.Version,
                    Damage.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/Health/Damage")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(Damage));
            }
        }

        #endregion METHODS
    }

}