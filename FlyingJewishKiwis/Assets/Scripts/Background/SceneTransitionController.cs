using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlyingJewishKiwis.Background
{
    public class SceneTransitionController : MonoBehaviour
    {
        public void ReplayLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadMainMenu()
        {
            LoadLevel(0);
        }

        public void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}