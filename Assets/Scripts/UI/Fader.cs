using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class Fader: MonoBehaviour
    {
        public CanvasGroup canvasGroup;
        public int fadeSpeed = 2;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void ActivateLayer()
        {
            float alpha = canvasGroup.alpha;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = Mathf.MoveTowards(alpha, 1, Time.deltaTime * fadeSpeed);
        }
    }
}