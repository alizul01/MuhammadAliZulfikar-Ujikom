using System;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager: MonoBehaviour
    {
        public static ScoreManager Instance;
        public int currentScore;
        public TMP_Text textScore;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            textScore.text = $"score: {currentScore}";
        }

        public void AddScore(int value)
        {
            currentScore += value;
            textScore.text = $"score: {currentScore}";
        }
    }
}