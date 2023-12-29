using FlyingJewishKiwis.Target;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlyingJewishKiwis.Background
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField]
        private Image _winMenu = null;
        [SerializeField]
        private TMP_Text _kiwisUsedDisplay = null;

        private static int numberOfTargetsRemianing = 0;
        private static Image winMenu = null;
        private static TMP_Text kiwisUsedDisplay = null;
        private static AudioSource audioSource = null;

        private void Awake()
        {
            winMenu = _winMenu;
            kiwisUsedDisplay = _kiwisUsedDisplay;
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            numberOfTargetsRemianing = FindObjectsByType<TargetHitResponse>(FindObjectsSortMode.None).Length;
        }

        public static void DecreaseRemainingTargets()
        {
            numberOfTargetsRemianing--;
            if (numberOfTargetsRemianing <= 0)
            {
                OnGameOver();
            }
        }

        private static void OnGameOver()
        {
            winMenu.gameObject.SetActive(true);
            kiwisUsedDisplay.text = $"You used {KiwiSpawner.KiwisUsed} kiwis";
            audioSource.Play();
        }
    }
}