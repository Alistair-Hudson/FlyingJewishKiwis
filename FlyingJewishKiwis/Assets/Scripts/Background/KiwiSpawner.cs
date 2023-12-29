using Cinemachine;
using FlyingJewishKiwis.JewishKiwi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.Background
{
    public class KiwiSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _kiwiPrefab = null;


        private static GameObject kiwiPrefab = null;
        private static Transform spawnTransform = null;
        private static AimTracker aimTracker = null;

        private void Start()
        {
            kiwiPrefab = _kiwiPrefab;
            spawnTransform = transform;
            aimTracker = GetComponentInChildren<AimTracker>();
            SpawnKiwi();
        }

        public static void SpawnKiwi()
        {
            GameObject newKiwi = Instantiate(kiwiPrefab, spawnTransform);
            aimTracker.InputForce = newKiwi.GetComponent<InputForce>();
        }
    }
}