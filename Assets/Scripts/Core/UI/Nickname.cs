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

        private void Awake()
        {
            PlayerNickname = PlayerPrefs.GetString("nickname", string.Empty);
            _inputField.text = PlayerNickname;
            ValidateNickname();
        }

        public void ValidateNickname()
        {
            if (_inputField.text != string.Empty)
            {
                _startButton.interactable = true;
                PlayerNickname = _inputField.text;
                PlayerPrefs.SetString("nickname", PlayerNickname);
            }
            else
            {
                _startButton.interactable = false;
            }
        }
    }
}