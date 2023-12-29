using Cinemachine;
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
        [SerializeField]
        private float _lifeTime = 5;
        [SerializeField]
        private float _fovIncrease = 0.1f;

        private InputReader inputReader = null;
        private Rigidbody myRigidbody = null;
        private float initialFOV = 0;
        
        public float TotalVelocity { get; private set; } = 0;

        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
            myRigidbody = GetComponent<Rigidbody>();
            initialFOV = Camera.main.fieldOfView;
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
                Camera.main.fieldOfView += _fovIncrease;
            }
        }

        private void OnTriggerReleaseHandle()
        {
            myRigidbody.freezeRotation = false;
            myRigidbody.velocity = transform.forward * TotalVelocity;
            TotalVelocity = 0;
            Camera.main.fieldOfView = initialFOV;
            GetComponent<DirectionControl>().enabled = false;
            StartCoroutine(RocketCountDown());
        }

        private IEnumerator RocketCountDown()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
    }
}