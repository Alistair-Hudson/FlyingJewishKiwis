using FlyingJewishKiwis.Target;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.Background
{
    public class ScoreCounter : MonoBehaviour
    {
        private static int numberOfTargetsRemianing = 0;

        private void Start()
        {
            numberOfTargetsRemianing = FindObjectsByType<TargetHitResponse>(FindObjectsSortMode.None).Length;
        }

        public static void DecreaseRemainingTargets()
        {
            numberOfTargetsRemianing--;
            if (numberOfTargetsRemianing <= 0)
            {
                Debug.Log("You win");
            }
        }
    }
}