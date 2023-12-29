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

        private void Start()
        {
            kiwiPrefab = _kiwiPrefab;
            spawnTransform = transform;
            SpawnKiwi();
        }

        public static void SpawnKiwi()
        {
            GameObject newKiwi = Instantiate(kiwiPrefab, spawnTransform);
        }
    }
}