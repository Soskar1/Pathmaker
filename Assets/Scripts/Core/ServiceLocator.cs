using UnityEngine;

namespace Pathmaker.Core
{
    public sealed class ServiceLocator : MonoBehaviour
    {
        [SerializeField] private Game _game;

        public static ServiceLocator Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        public Game Game => _game;
    }
}