using TMPro;
using UnityEngine;

namespace Pathmaker.Core
{
    public class StarCounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private StarCounter _counter;

        private void OnEnable() => _counter.OnStarGained += SetText;
        private void OnDisable() => _counter.OnStarGained -= SetText;

        private void SetText(int stars) => _text.SetText(stars.ToString()); 
    }
}