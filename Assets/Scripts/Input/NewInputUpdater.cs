using System;
using UnityEngine;
using Sjouke.CodeArchitecture.Variables;
using Sjouke.CodeArchitecture.Events;

namespace Sjouke.Input.New
{
    public enum InputButtonState { Press, Hold, Release }
    
    [Serializable]
    public sealed class ValueInputObject
    {
        [Tooltip("The name of this input.")]
        public string Name;
        [Tooltip("The positive key of the input.")]
        public KeyCode PositiveKey;
        [Tooltip("The required state of the key for the positive input to register.")]
        public InputButtonState RequiredState;
        [Tooltip("The negative key of the input.")]
        public KeyCode NegativeKey;
        [Tooltip("The required state of the negative key for the input to register.")]
        public InputButtonState RequiredNegativeState;
        [Tooltip("The FloatReference the value will be stored in.")]
        public FloatReference InputReference;
    }

    [Serializable]
    public sealed class ButtonInputObject
    {
        [Tooltip("The name of this input.")]
        public string Name;
        public KeyCode Button;
        [Tooltip("The GameEvent to trigger if the input is pressed.")]
        public GameEvent PressInputEvent;
        [Tooltip("The GameEvent to trigger if the input is held.")]
        public GameEvent HoldInputEvent;
        [Tooltip("The GameEvent to trigger if the input is released.")]
        public GameEvent ReleaseInputEvent;
    }

    public sealed class NewInputUpdater : MonoBehaviour
    {
        public ValueInputObject[] InputAxes;
        public ButtonInputObject[] InputButtons;

        private void Update()
        {
            if (InputAxes.Length > 0) UpdateInputAxes();
            if (InputButtons.Length > 0) UpdateInputButtons();
        }

        private void UpdateInputAxes()
        {
            foreach (var input in InputAxes)
            {
                try
                {
                    input.InputReference.Variable.Value = (CheckValue(input.PositiveKey, input.RequiredState) ? 1 : 0) - (CheckValue(input.NegativeKey, input.RequiredNegativeState) ? 1 : 0);
                }
                catch (Exception e)
                {
                    Debug.LogError($"NewInputUpdater (InputAxes): {e.Message}");
                }
                return;
            }
        }

        private void UpdateInputButtons()
        {
            foreach (var input in InputButtons)
            {
                //try
                //{
                    if (input.PressInputEvent != null && CheckButton(input, InputButtonState.Press))
                        input.PressInputEvent.Raise();
                    if (input.HoldInputEvent != null && CheckButton(input, InputButtonState.Hold))
                        input.HoldInputEvent.Raise();
                    if (input.ReleaseInputEvent != null && CheckButton(input, InputButtonState.Release))
                        input.ReleaseInputEvent.Raise();
                //}
                //catch (Exception e)
                //{
                //    Debug.LogError($"NewInputUpdater (InputButtons): {e.Message}");
                //}
            }
        }

        private bool CheckValue(KeyCode inputKey, InputButtonState state)
        {
            switch (state)
            {
                case InputButtonState.Press: return UnityEngine.Input.GetKeyDown(inputKey);
                case InputButtonState.Hold: return UnityEngine.Input.GetKey(inputKey);
                case InputButtonState.Release: return UnityEngine.Input.GetKeyUp(inputKey);
                default : return false;
            }
        }

        private bool CheckButton(ButtonInputObject input, InputButtonState state)
        {
            switch (state)
            {
                case InputButtonState.Press : return UnityEngine.Input.GetKeyDown(input.Button);
                case InputButtonState.Hold : return UnityEngine.Input.GetKey(input.Button);
                case InputButtonState.Release : return UnityEngine.Input.GetKeyUp(input.Button);
                default : return false;
            }
        }
    }
}