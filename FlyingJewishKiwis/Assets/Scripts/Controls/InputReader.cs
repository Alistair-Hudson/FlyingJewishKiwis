using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FlyingJewishKiwis.Controls
{
    public class InputReader : MonoBehaviour, Input.IAimAndShootActions
    {
        private Input input = null;

        public bool IsHoldingTrigger { get; private set; } = false;

        public event Action TriggerPulled;
        public event Action TriggerRelease;

        private void Start()
        {
            input = new Input();
            input.AimAndShoot.SetCallbacks(this);
            input.AimAndShoot.Enable();
        }

        private void OnDestroy()
        {
            input.AimAndShoot.Disable();
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                IsHoldingTrigger = true;
                TriggerPulled?.Invoke();
            }
            else if (context.canceled)
            {
                IsHoldingTrigger = false;
                TriggerRelease?.Invoke();
            }
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            
        }
    }
}