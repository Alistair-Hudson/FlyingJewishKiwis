using FlyingJewishKiwis.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.JewishKiwi
{
    [RequireComponent(typeof(InputReader), typeof(Rigidbody), typeof(DirectionControl))]
    public class InputForce : MonoBehaviour
    {
        [SerializeField]
        private float _velocityAddedPerSecond = 1;

        private InputReader inputReader = null;
        private Rigidbody myRigidbody = null;
        
        public float TotalVelocity { get; private set; } = 0;

        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
            myRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            inputReader.TriggerRelease += OnTriggerReleaseHandle;
        }

        private void OnDestroy()
        {
            inputReader.TriggerRelease -= OnTriggerReleaseHandle;
        }

        private void Update()
        {
            if (inputReader.IsHoldingTrigger)
            {
                TotalVelocity += _velocityAddedPerSecond * Time.deltaTime;
            }
        }

        private void OnTriggerReleaseHandle()
        {
            myRigidbody.freezeRotation = false;
            myRigidbody.velocity = transform.forward * TotalVelocity;
            TotalVelocity = 0;
            GetComponent<DirectionControl>().enabled = false;
        }
    }
}