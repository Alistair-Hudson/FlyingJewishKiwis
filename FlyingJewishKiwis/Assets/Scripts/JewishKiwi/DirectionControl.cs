using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.JewishKiwi
{
    public class DirectionControl : MonoBehaviour
    {
        private Camera mainCamera = null;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            transform.forward = mainCamera.transform.forward;
        }
    }
}