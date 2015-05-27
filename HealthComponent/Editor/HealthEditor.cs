using UnityEditor;
using UnityEngine;

namespace HealthEx.HealthComponent {

    [CustomEditor(typeof(Health))]
    [CanEditMultipleObjects]
    public sealed class HealthEditor : Editor {
        #region FIELDS

        private Health Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable() {
            Script = (Health)target;

            description = serializedObject.FindProperty("description");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    Health.Version,
                    Health.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/Health/Health")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(Health));
            }
        }

        #endregion METHODS
    }

}