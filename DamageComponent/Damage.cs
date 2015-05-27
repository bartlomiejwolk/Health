using UnityEngine;
using System.Collections;
using HealthEx.HealthComponent;

namespace HealthEx.DamageComponent {

    public sealed class Damage : MonoBehaviour {

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
        private string componentName = "Damage";
#pragma warning restore0414

        #endregion

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        /// <summary>
        /// Damage to be applied to the <c>Health</c> component.
        /// </summary>
        [SerializeField]
        private int damageValue;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Damage to be applied to the <c>Health</c> component.
        /// </summary>
        public int DamageValue {
            get { return damageValue; }
            set { damageValue = value; }
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

        // todo filter by tag and layer
        private void OnCollisionEnter(Collision collision) {
            var healthComponent = collision.gameObject.GetComponent<Health>();

            if (healthComponent == null) return;

            // Apply damage.
            healthComponent.HealthValue -= DamageValue;
        }

        private void OnCollisionStay(Collision collision) { }

        private void OnCollisionExit(Collision collision) { }
        
        #endregion

        #region EVENT INVOCATORS
        #endregion

        #region EVENT HANDLERS
        #endregion

        #region METHODS
        #endregion

    }

}