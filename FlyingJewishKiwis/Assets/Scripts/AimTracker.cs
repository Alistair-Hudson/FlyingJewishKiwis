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
        private Transform _maxRangeMarkerTransform = null;
        [SerializeField]
        private int _numberOfPoints = 100;

        private UnknownComponent meshCreator = null;
        private InputForce inputForce = null;
        private Vector3[] pointsList;

        private void Awake()
        {
            meshCreator = GetComponent<UnknownComponent>();
            inputForce = GetComponentInParent<InputForce>();
            pointsList = new Vector3[_numberOfPoints];
        }

        private void Start()
        {
            GetComponentInParent<InputReader>().TriggerPulled += delegate { gameObject.SetActive(true); };
            GetComponentInParent<InputReader>().TriggerRelease += delegate { gameObject.SetActive(false); };
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            GetComponentInParent<InputReader>().TriggerPulled -= delegate { gameObject.SetActive(true); };
            GetComponentInParent<InputReader>().TriggerRelease -= delegate { gameObject.SetActive(false); };
        }

        private void Update()
        {
            Vector3 initalVelocity = inputForce.TotalVelocity * inputForce.transform.forward;
            float timeOfFlight = ProjectileFormulae.TimeOfFlight(initalVelocity.y);
            float timeIncrment = timeOfFlight / (pointsList.Length);
            for (int i = 0; i < pointsList.Length; i++)
            {
                float xPosition = initalVelocity.x * timeIncrment * i;
                float yPosition = ProjectileFormulae.VerticalDisplacement(initalVelocity.y, timeIncrment * i);
                float zPosition = initalVelocity.z * timeIncrment * i;
                pointsList[i] = new Vector3(xPosition, yPosition, zPosition);
            }
            meshCreator.UnknownMethod(pointsList);
            _maxRangeMarkerTransform.position = pointsList[pointsList.Length - 1];
        }
    }
}