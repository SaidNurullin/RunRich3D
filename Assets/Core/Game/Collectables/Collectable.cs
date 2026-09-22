using UnityEngine;

namespace Game.Collectables
{
    public enum CollectableTypes
    {
        None,
        Good,
        Bad,
    }
    public class Collectable : MonoBehaviour
    {
        public CollectableTypes collectableType;
        public int value;
    }
}
