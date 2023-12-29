using DefaultNamespace;
using FlyingJewishKiwis.Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.JewishKiwi
{
    [RequireComponent(typeof(UnknownComponent))]
    public class AimTracker : MonoBehaviour
    {
        [SerializeField]
        private int _numberOfPoints = 100;
        [SerializeField]
        private float _flightTime = 5f;

        private UnknownComponent meshCreator = null;
        private Vector3[] pointsList;

        public InputForce InputForce = null;

        private void Awake()
        {
            meshCreator = GetComponent<UnknownComponent>();
            pointsList = new Vector3[_numberOfPoints];
        }

        private void Start()
        {
            GetComponentInParent<InputReader>().TriggerPulled += delegate { gameObject.SetActive(true); };
            GetComponentInParent<InputReader>().TriggerRelease += delegate { gameObject.SetActive(false); };
        }

        private void OnDestroy()
        {
            GetComponentInParent<InputReader>().TriggerPulled -= delegate { gameObject.SetActive(true); };
            GetComponentInParent<InputReader>().TriggerRelease -= delegate { gameObject.SetActive(false); };
        }

        private void Update()
        {
            if (!InputForce)
            {
                return;
            }
            Vector3 initalVelocity = InputForce.TotalVelocity * InputForce.transform.forward;
            float timeIncrment = _flightTime / (pointsList.Length);
            for (int i = 0; i < pointsList.Length; i++)
            {
                Vector2 horizontalVelocity = new Vector2(initalVelocity.x, initalVelocity.z);
                float xPosition = horizontalVelocity.x * timeIncrment * i;
                float yPosition = ProjectileFormulae.VerticalDisplacement(initalVelocity.y, timeIncrment * i);
                float zPosition = horizontalVelocity.y * timeIncrment * i;
                pointsList[i] = new Vector3(xPosition, yPosition, zPosition);
            }
            meshCreator.UnknownMethod(pointsList);

        }
    }
}