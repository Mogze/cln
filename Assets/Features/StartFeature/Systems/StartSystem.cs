using Entitas;
using UnityEngine;

namespace cln
{
    public class StartSystem : IInitializeSystem
    {
        public void Initialize()
        {
            Debug.Log("Initialize");
        }
    }
}