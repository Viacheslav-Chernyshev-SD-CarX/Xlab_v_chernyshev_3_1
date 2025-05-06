using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public static class GameEvents
    {
        public static event System.Action onCollisionStone;
        public static System.Action onStickHit;
        

        public static void CollisionStonesInvoke(Collision collision)
        {
            onCollisionStone?.Invoke();
            SoundManager.Instance?.PlayRandomStoneSound();
        }

        public static void StickHit()
        { 
            onStickHit?.Invoke();
            SoundManager.Instance?.PlayRandomHitSound();
        }

    }
}
