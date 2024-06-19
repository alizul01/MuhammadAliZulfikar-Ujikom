using System;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class TimeManager: MonoBehaviour
    {
        public float levelTime = 60f;
        public TMP_Text timeUI;

        private void FixedUpdate()
        {
            levelTime -= Time.deltaTime;
            timeUI.text = $"Time: {Mathf.RoundToInt(levelTime)}";
            if (levelTime <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}