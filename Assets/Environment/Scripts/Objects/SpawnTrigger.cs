using PlayerLogic;
using UnityEngine;

namespace Environment.Objects
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnTrigger : MonoBehaviour
    {
        [SerializeField] private ObjectType _objectType;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Player>(out Player player))
            {
                return;
            }

            ObjectSpawner.Instance.SpawnObject(_objectType);
        }
    }
}
