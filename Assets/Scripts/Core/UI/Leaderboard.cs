using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;

namespace Pathmaker.Core.UI
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> _names;
        [SerializeField] private List<TextMeshProUGUI> _scores;
        [SerializeField] private string _leaderboardKey;

        [SerializeField] private Nickname _nickname;

        private void Start() => GetLeaderboard();

        public void GetLeaderboard()
        {
            LeaderboardCreator.GetLeaderboard(_leaderboardKey, msg =>
            {
                int loopLength = (msg.Length < _names.Count) ? msg.Length : _names.Count;
                for (int i = 0; i < loopLength; ++i)
                {
                    _names[i].text = msg[i].Username;
                    _scores[i].text = msg[i].Score.ToString();
                }
            });
        }

        public void SetLeaderboardEntry(int score)
        {
            LeaderboardCreator.UploadNewEntry(_leaderboardKey, _nickname.PlayerNickname, score, msg =>
            {
                GetLeaderboard();
            });
        }
    }
}