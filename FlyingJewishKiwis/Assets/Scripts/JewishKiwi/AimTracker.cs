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
        [SerializeField]
        private float _flightTime = 5f;

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
            float timeIncrment = _flightTime / (pointsList.Length);
            for (int i = 0; i < pointsList.Length; i++)
            {
                Vector2 horizontalVelocity = new Vector2(initalVelocity.x, initalVelocity.z);
                float xPosition = 0;//
                float yPosition = ProjectileFormulae.VerticalDisplacement(initalVelocity.y, timeIncrment * i);
                float zPosition = Mathf.Abs(horizontalVelocity.magnitude * timeIncrment * i);//Ensures the mesh is always in the forward direction of the kiwi
                pointsList[i] = new Vector3(xPosition, yPosition, zPosition);
            }
            meshCreator.UnknownMethod(pointsList);
            _maxRangeMarkerTransform.position = pointsList[pointsList.Length - 1];
        }
    }
}