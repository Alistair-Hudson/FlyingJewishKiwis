using FlyingJewishKiwis.DevTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.Target
{
    public class PathFollower : MonoBehaviour
    {
        [SerializeField]
        private WayPoint currentWayPoint = null;
        [SerializeField]
        private float speed = 1;
        [SerializeField]
        private float stopDistance = 0.1f;

        private void Update()
        {
            if (!currentWayPoint)
            {
                return;
            }

            Vector3 direction = currentWayPoint.Position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentWayPoint.Position) <= stopDistance)
            {
                currentWayPoint = currentWayPoint.NextWayPoint;
            }
        }
    }
}