// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the Health extension for Unity. Licensed under the MIT
// license. See LICENSE file in the project root folder.

using System;
using UnityEngine;
using UnityEngine.Events;

namespace HealthEx.HealthComponent {

    public sealed class Health : MonoBehaviour {
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
        private string componentName = "Health";

#pragma warning restore0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        [SerializeField]
        private HealthUpdatedCallback healthUpdatedCallback;

        [SerializeField]
        private int healthValue = 100;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the
        ///     component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        ///     Callback to execute on health value change. Current health value is
        ///     passed as an argument.
        /// </summary>
        public HealthUpdatedCallback HealthUpdatedCallback {
            get { return healthUpdatedCallback; }
            set { healthUpdatedCallback = value; }
        }

        /// <summary>
        ///     Health value.
        /// </summary>
        public int HealthValue {
            get { return healthValue; }
            set {
                var prevHealthValue = healthValue;
                healthValue = value;

                if (healthValue != prevHealthValue) {
                    HealthUpdatedCallback.Invoke(healthValue);
                }
            }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() {
        }

        private void FixedUpdate() {
        }

        private void LateUpdate() {
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
    }

    // todo move to a separate file
    [Serializable]
    public class HealthUpdatedCallback : UnityEvent<int> {

    }

}