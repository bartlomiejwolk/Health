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

        /// <summary>
        /// Specifys where to look for the <c>Health</c> component.
        /// </summary>
        [SerializeField]
        private LookupType lookupType;

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

        public LookupType LookupType {
            get { return lookupType; }
            set { lookupType = value; }
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
            var hitGameObject = hitInfo.transform.gameObject;
            var healthComponent = GetHealthComponent(hitGameObject);

            if (healthComponent == null) return;

            // Apply damage.
            healthComponent.HealthValue =
                healthComponent.HealthValue - DamageValue;
        }

        /// <summary>
        /// Look for Health component in the specified game object.
        /// </summary>
        /// <param name="hitGameObject"></param>
        /// <returns></returns>
        private Health GetHealthComponent(GameObject hitGameObject) {
            Health healthComponent = null;

            switch (LookupType) {
                case LookupType.Parent:
                    healthComponent =
                        hitGameObject.GetComponentInParent<Health>();
                    break;
                case LookupType.Children:
                    healthComponent =
                        hitGameObject.GetComponentInChildren<Health>();
                    break;
                case LookupType.ParentAndChildren:
                    healthComponent =
                        hitGameObject.GetComponentInParent<Health>();

                    if (healthComponent == null) break;

                    healthComponent =
                        hitGameObject.GetComponentInChildren<Health>();

                    break;
            }

            return healthComponent;
        }

        public void ApplyDamage(GameObject other) {
            var healthComponent = GetHealthComponent(other);

            if (healthComponent == null) return;

            // Apply damage.
            healthComponent.HealthValue =
                healthComponent.HealthValue - damageValue;
        }

        #endregion METHODS
    }

}