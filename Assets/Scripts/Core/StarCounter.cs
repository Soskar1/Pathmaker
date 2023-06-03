using UnityEngine;
using System;

namespace Pathmaker.Core
{
    public class StarCounter : MonoBehaviour
    {
        private int _stars;

        public Action<int> OnStarGained;

        public void Add()
        {
            ++_stars;
            OnStarGained?.Invoke(_stars);
        }
    }
}