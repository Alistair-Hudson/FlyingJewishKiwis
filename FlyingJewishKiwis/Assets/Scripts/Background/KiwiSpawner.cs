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
        [SerializeField]
        private AudioClip _spawnSFX = null;


        private static GameObject kiwiPrefab = null;
        private static Transform spawnTransform = null;
        private static AimTracker aimTracker = null;
        private static AudioSource audioSource = null;
        private static AudioClip spawnSFX = null;

        public static int KiwisUsed { get; private set; } = 0;

        private void Start()
        {
            KiwisUsed = 0;
            kiwiPrefab = _kiwiPrefab;
            spawnTransform = transform;
            aimTracker = GetComponentInChildren<AimTracker>();
            audioSource = GetComponent<AudioSource>();
            spawnSFX = _spawnSFX;
            SpawnKiwi();
        }

        public static void SpawnKiwi()
        {
            GameObject newKiwi = Instantiate(kiwiPrefab, spawnTransform);
            aimTracker.InputForce = newKiwi.GetComponent<InputForce>();
            audioSource.PlayOneShot(spawnSFX);
            Camera.main.GetComponent<KiwiTracker>().Kiwi = newKiwi.transform;
            KiwisUsed++;
        }
    }
}