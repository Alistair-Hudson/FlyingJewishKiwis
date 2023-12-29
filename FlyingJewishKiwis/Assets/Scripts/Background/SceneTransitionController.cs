using FlyingJewishKiwis.Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlyingJewishKiwis.Background
{
    public class SceneTransitionController : MonoBehaviour
    {
        private void Start()
        {
            InputReader.QuitLevel += OnQuitLevelHandler;
        }

        private void OnDestroy()
        {
            InputReader.QuitLevel -= OnQuitLevelHandler;
        }

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

        private void OnQuitLevelHandler()
        {
            LoadMainMenu();
        }

    }
}