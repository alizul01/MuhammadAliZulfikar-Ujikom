using System;
using Character;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class TimeManager: MonoBehaviour
    {
        public float levelTime = 60f;
        public TMP_Text timeUI;
        public UnityEvent onGameOver;

        public PlayerController player;

        public CanvasGroup pauseMenu;
        private bool _gamePaused;
        private bool _gameOver;

        private void Update()
        {
            if (_gameOver) return;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_gamePaused)
                {
                    Unpause();
                }
                else
                {
                    pauseMenu.gameObject.SetActive(true);
                    _gamePaused = true;
                    player.FreezePlayer();
                    Time.timeScale = 0;
                }
            }
        }

        public void Unpause()
        {
            pauseMenu.gameObject.SetActive(false);
            _gamePaused = false;
            player.UnfreezePlayer();
            Time.timeScale = 1;
        }

        private void FixedUpdate()
        {
            levelTime -= Time.deltaTime;
            timeUI.text = $"Time: {Mathf.RoundToInt(levelTime)}";
            if (levelTime <= 0)
            {
                onGameOver?.Invoke();
                _gameOver = true;
            }
        }
    }
}