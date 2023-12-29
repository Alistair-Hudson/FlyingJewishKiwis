using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.Background
{
    public class KiwiTracker : MonoBehaviour
    {
        public Transform Kiwi = null;

        private void Update()
        {
            transform.LookAt(Kiwi);
        }
    }
}