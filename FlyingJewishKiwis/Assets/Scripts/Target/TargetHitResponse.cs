using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.Target
{
    [RequireComponent(typeof(Collider))]
    public class TargetHitResponse : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{gameObject.name} hit!!!!!");
            Destroy(gameObject);
        }
    }
}