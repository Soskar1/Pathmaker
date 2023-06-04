using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pathmaker.Core.UI
{
    public class Nickname : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _startButton;
        
        public string PlayerNickname { get; private set; }

        public void ValidateNickname()
        {
            if (_inputField.text != string.Empty)
            {
                _startButton.interactable = true;
                PlayerNickname = _inputField.text;
            }
            else
            {
                _startButton.interactable = false;
            }
        }
    }
}