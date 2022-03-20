using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Level : MonoBehaviour
    {
        public event Action LevelStarted;
        
        public void StartLevel()
        {
            LevelStarted?.Invoke();
        }
    }
}