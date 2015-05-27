using UnityEngine;
using System.Collections;

namespace HealthEx.HealthComponent {

    public sealed class Health : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "Health";

        #endregion

        #region DELEGATES
        #endregion

        #region EVENTS
        #endregion

        #region FIELDS

#pragma warning disable 0414
        /// <summary>
        /// Allows identify component in the scene file when reading it with
        /// text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "Health";
#pragma warning restore0414

        #endregion

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        #endregion

        #region UNITY MESSAGES

        private void Awake() { }

        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() { }

        private void Reset() { }

        private void Start() { }

        private void Update() { }

        private void OnValidate() { }

        #endregion

        #region EVENT INVOCATORS
        #endregion

        #region EVENT HANDLERS
        #endregion

        #region METHODS
        #endregion

    }

}