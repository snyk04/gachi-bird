using UnityEngine;
using UserInterface;

namespace Environment.Objects
{
    public sealed class Checkpoint : SpawnTrigger
    {
        private new void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            ScoreManager.Instance.GivePoints();
        }
    }
}
