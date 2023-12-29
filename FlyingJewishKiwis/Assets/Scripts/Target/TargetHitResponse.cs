using FlyingJewishKiwis.Background;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.Target
{
    [RequireComponent(typeof(Collider))]
    public class TargetHitResponse : MonoBehaviour
    {
        private void OnDestroy()
        {
            ScoreCounter.DecreaseRemainingTargets();
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}