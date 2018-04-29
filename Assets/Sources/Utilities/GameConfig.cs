using UnityEngine;

namespace cln
{
    public static class GameConfig
    {
        public static readonly Vector3 JumpVelocity = new Vector3(0f, 25f, 0f);
        public static readonly Vector3 CubeMoveVelocity = new Vector3(1f, 0f, 0f);
        public static readonly Vector3 JumpDeceleration = new Vector3(0f, -80f, 0f);
    }
}