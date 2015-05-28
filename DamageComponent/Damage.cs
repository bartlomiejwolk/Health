// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the Health extension for Unity. Licensed under the MIT
// license. See LICENSE file in the project root folder.

using HealthEx.HealthComponent;
using UnityEngine;

namespace HealthEx.DamageComponent {

    public sealed class Damage : MonoBehaviour {
        #region CONSTANTS

        public const string Extension = "Health";
        public const string Version = "v0.1.0";

        #endregion CONSTANTS

        #region FIELDS

#pragma warning disable 0414

        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
        [SerializeField]
        private string componentName = "Damage";

#pragma warning restore0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        /// <summary>
        ///     Damage to be applied to the <c>Health</c> component.
        /// </summary>
        [SerializeField]
        private int damageValue = 5;

        [SerializeField]
        private string description = "Description";

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Damage to be applied to the <c>Health</c> component.
        /// </summary>
        public int DamageValue {
            get { return damageValue; }
            set { damageValue = value; }
        }

        /// <summary>
        ///     Optional text to describe purpose of this instance of the
        ///     component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() {
        }

        private void FixedUpdate() {
        }

        private void LateUpdate() {
        }

        // todo not tested todo filter by tag and layer
        private void OnCollisionEnter(Collision collision) {
            var healthComponent =
                collision.gameObject.GetComponentInChildren<Health>();

            if (healthComponent == null) return;

            // Apply damage.
            healthComponent.HealthValue -= DamageValue;
        }

        private void OnCollisionExit(Collision collision) {
        }

        private void OnCollisionStay(Collision collision) {
        }

        private void OnEnable() {
        }

        private void OnValidate() {
        }

        private void Reset() {
        }

        private void Start() {
        }

        private void Update() {
        }

        #endregion UNITY MESSAGES

        #region METHODS

        // todo filter by tag and layer
        public void ApplyDamage(RaycastHit hitInfo) {
            var healthComponent =
                hitInfo.transform.gameObject.GetComponentInChildren<Health>();

            if (healthComponent == null) return;

            // Apply damage.
            healthComponent.HealthValue =
                healthComponent.HealthValue - DamageValue;
        }

        public void ApplyDamage(GameObject other) {
            //Debug.Log(other);
            var healthComponent = other.GetComponentInChildren<Health>();

            if (healthComponent == null) return;

            // Apply damage.
            healthComponent.HealthValue =
                healthComponent.HealthValue - damageValue;
        }

        #endregion METHODS
    }

}