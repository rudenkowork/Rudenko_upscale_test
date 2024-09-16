using System;
using System.Collections;
using Infrastructure.Services.InputManagement;
using Infrastructure.Services.SoundsManagement;
using Infrastructure.Services.UIManagement.Windows;
using UnityEngine;
using Zenject;

namespace GameControllers.Tools.PushPanels
{
    public class TrapPushPanel : PushPanel
    {
        private const float ConeTargetHeight = 15f;

        [SerializeField] private Transform[] Cones;

        protected override float PushedPosition { get; set; } = -0.015f;
        protected override bool AbleToPush { get; set; } = true;

        private IWindowService _windowService;
        private IInputService _inputService;
        private ISoundService _soundService;

        [Inject]
        public void Construct(IWindowService windowService, IInputService inputService, ISoundService soundService)
        {
            _windowService = windowService;
            _inputService = inputService;
            _soundService = soundService;
        }

        private void OnDestroy() => 
            StopAllCoroutines();

        protected override void TriggerPanelAction()
        {
            StartCoroutine(SharpenCones());
            WindowBase window = _windowService.Open(WindowType.LOSS, UIRoot);
            _soundService.PlayOnTrapSound(SoundsSource.Instance, () =>
            {
                window.HandleAllButtons(true);
                StopAllCoroutines();
            });
            _inputService.DisableAll();
        }

        private IEnumerator SharpenCones()
        {
            bool allConesSharpened = false;

            while (!allConesSharpened)
            {
                foreach (Transform cone in Cones)
                {
                    Vector3 targetScale = new Vector3(cone.localScale.x, ConeTargetHeight, cone.localScale.z);
                    Vector3 targetPosition = new Vector3(cone.localPosition.x, ConeTargetHeight, cone.localPosition.z);

                    cone.localPosition = Vector3.Lerp(cone.localPosition, targetPosition, Time.deltaTime * 2f);
                    cone.localScale = Vector3.Lerp(cone.localScale, targetScale, Time.deltaTime * 2f);

                    if (HasReachedTarget(cone.localPosition, targetPosition) &&
                        HasReachedTarget(cone.localScale, targetScale))
                    {
                        allConesSharpened = true;
                    }
                }

                yield return null;
            }
        }

        private static bool HasReachedTarget(Vector3 current, Vector3 target, float tolerance = 0.01f) =>
            Vector3.Distance(current, target) <= tolerance;
    }
}