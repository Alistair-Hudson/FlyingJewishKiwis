using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.JewishKiwi
{
    [RequireComponent(typeof(InputForce))]
    public class DirectionControl : MonoBehaviour
    {
        private InputForce inputForce = null;

        private void Awake()
        {
            inputForce = GetComponent<InputForce>();
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out RaycastHit hit))
            {
                return;
            }
            Vector3 worldTargetLocation = hit.point;
            float initalVelocity = inputForce.TotalVelocity;
            float maxRange = new Vector2(worldTargetLocation.x, worldTargetLocation.z).magnitude;
            float xAngle = -90 + ProjectileFormulae.AngleFromRange(maxRange, initalVelocity) * Mathf.Rad2Deg; //Inverted due to Unity coordinates
            xAngle = xAngle <= -90 ? 0 : xAngle;
            float yAngle = Mathf.Atan(worldTargetLocation.x / worldTargetLocation.z) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
            transform.rotation = rotation;
            
        }
    }
}