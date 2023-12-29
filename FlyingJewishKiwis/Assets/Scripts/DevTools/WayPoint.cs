using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.DevTools
{
    public class WayPoint : MonoBehaviour
    {
        [field: SerializeField]
        public WayPoint NextWayPoint { get; private set; } = null;

        public Vector3 Position { get => transform.position; }

        private void OnDrawGizmos()
        {
            if (NextWayPoint)
            {
                Gizmos.DrawLine(Position, NextWayPoint.Position);
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(Position, 0.5f);
        }
    }
}