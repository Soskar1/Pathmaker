using UnityEngine;
using TMPro;

namespace Pathmaker.Core.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Score _score;

        private void OnEnable() => _score.OnGainedPoints += SetScore;
        private void OnDisable() => _score.OnGainedPoints -= SetScore;

        private void SetScore(int score) => _scoreText.SetText(score.ToString());
    }
}