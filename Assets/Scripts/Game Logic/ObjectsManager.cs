using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    public int AmountOfSpawnedGround { get; set; }
    public int AmountOfSpawnedObstacles { get; set; }
    public int AmountOfSpawnedBackground { get; set; }
    public int AmountOfSpawnedBoosters { get; set; }

    void Awake()
    {
        AmountOfSpawnedGround = 0;
        AmountOfSpawnedObstacles = 0;
        AmountOfSpawnedBackground = 0;
        AmountOfSpawnedBoosters = 0;
    }
}
