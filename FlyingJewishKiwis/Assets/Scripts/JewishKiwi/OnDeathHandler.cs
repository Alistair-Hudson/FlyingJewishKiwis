using FlyingJewishKiwis.Background;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyingJewishKiwis.JewishKiwi
{

    public class OnDeathHandler : MonoBehaviour
    {
        private void OnDestroy()
        {
            KiwiSpawner.SpawnKiwi();
        }
    }
}