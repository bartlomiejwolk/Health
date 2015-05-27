// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
//  
// This file is part of the Health extension for Unity.
// Licensed under the MIT license. See LICENSE file in the project root folder.

using System;
using UnityEngine;
using UnityEngine.Events;

namespace HealthEx.HealthComponent {

    // todo move to a separate file
    [Serializable]
    public class HealthUpdatedCallback : UnityEvent<int> { }

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

        [SerializeField]
        private int healthValue = 100;

        [SerializeField]
        private HealthUpdatedCallback healthUpdatedCallback;

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
        /// Health value.
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

        /// <summary>
        /// Callback to execute on health value change.
        /// Current health value is passed as an argument.
        /// </summary>
        public HealthUpdatedCallback HealthUpdatedCallback {
            get { return healthUpdatedCallback; }
            set { healthUpdatedCallback = value; }
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