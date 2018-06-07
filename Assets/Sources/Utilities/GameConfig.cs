using UnityEngine;

namespace cln
{
    public static class GameConfig
    {
        public static readonly Vector3 CubeMoveVelocity = new Vector3(5f, 0f, 0f);
        public static readonly Vector3 CubeVelocityStep = new Vector3(1f, 0f, 0f);
        public const float CubeVelocityStepTimer = 5f;
        public static readonly Vector3 JumpVelocity = new Vector3(0f, 35f, 0f);
        public static readonly Vector3 JumpDeceleration = new Vector3(0f, -2f, 0f);

        public const string ObstacleTag = "Obstacle";
        public const string PlatformTag = "Platform";
    }
}