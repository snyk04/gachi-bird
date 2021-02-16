using System.Collections;
using UnityEngine;


public class SpawningObjectsManager : MonoBehaviour
{
    #region Properties

    private PrefabsManager prefabs;
    private ObjectsManager objects;
    private ComponentsManager components;

    public Coroutine GroundSpawningCoroutine { get; set; }
    public Coroutine ObstacleSpawningCoroutine { get; set; }
    public Coroutine BackgroundSpawningCoroutine { get; set; }
    public Coroutine BoosterSpawningCoroutine { get; set; }

    public Vector2 PlayerStartPosition { get; set; }

    #endregion

    void Awake()
    {
        prefabs = GetComponent<PrefabsManager>();
        objects = GetComponent<ObjectsManager>();
        components = GetComponent<ComponentsManager>();
    }

    #region Coroutines and methods

    public void DrawBackgroundPart(int amountOfBackground)
    {
        for (int i = 0; i < amountOfBackground; i++) {
            Instantiate(prefabs.backgroundPrefab,
                new Vector2(14.25f * objects.AmountOfSpawnedBackground, 0),
                Quaternion.identity,
                components.objectsMenu.GetChild(0)
                );

            objects.AmountOfSpawnedBackground += 1;
        }
    }
    public void DrawObstacle(int amountOfObstacles)
    {
        for (int i = 0; i < amountOfObstacles; i++) {
            float newX = objects.AmountOfSpawnedObstacles * 15 + PlayerStartPosition.x + 20;
            float newY = Random.Range(-3, 5.5f);

            Instantiate(prefabs.obstaclePrefab,
                new Vector2(newX, newY),
                Quaternion.identity,
                components.objectsMenu.GetChild(1)
                );

            objects.AmountOfSpawnedObstacles += 1;
        }
    }
    public void DrawGroundPart(int amountOfParts)
    {
        for (int i = 0; i < amountOfParts; i++) {
            Instantiate(prefabs.groundPrefab,
                new Vector2(16.75f * objects.AmountOfSpawnedGround, -10),
                Quaternion.identity,
                components.objectsMenu.GetChild(2)
                );

            objects.AmountOfSpawnedGround += 1;
        }
    }
    public void DrawBooster(int amountOfBoosters)
    {
        for (int i = 0; i < amountOfBoosters; i++) {
            System.Random rnd = new System.Random();
            float newX = objects.AmountOfSpawnedBoosters * 60 + PlayerStartPosition.x + 25 + 15 * rnd.Next(1, 4) + Random.Range(0f, 7f);
            float newY = Random.Range(-5f, 5f);
            int amountOfBoostersPrefabs = prefabs.boostersArray.Length;

            rnd = new System.Random();
            Instantiate(prefabs.boostersArray[rnd.Next(0, amountOfBoostersPrefabs)],
                new Vector2(newX, newY),
                Quaternion.identity,
                components.objectsMenu.GetChild(3)
                );
            objects.AmountOfSpawnedBoosters += 1;
        }
    }

    public IEnumerator DrawGround(float timeDelay)
    {
        while (true) {
            yield return new WaitForSeconds(timeDelay);
            DrawGroundPart(1);
        }
    }
    public IEnumerator DrawObstacles(float timeDelay)
    {
        while (true) {
            yield return new WaitForSeconds(timeDelay);
            DrawObstacle(1);
        }
    }
    public IEnumerator DrawBackground(float timeDelay)
    {
        while (true) {
            yield return new WaitForSeconds(timeDelay);
            DrawBackgroundPart(1);
        }
    }
    public IEnumerator DrawBoosters(float timeDelay)
    {
        while (true) {
            yield return new WaitForSeconds(timeDelay);
            DrawBooster(1);
        }
    }

    public void StartSpawnCoroutines(float bgTime, float obstacleTime, float groundTime, float boosterTime)
    {
        BackgroundSpawningCoroutine = StartCoroutine(DrawBackground(bgTime));
        ObstacleSpawningCoroutine = StartCoroutine(DrawObstacles(obstacleTime));
        GroundSpawningCoroutine = StartCoroutine(DrawGround(groundTime));
        BoosterSpawningCoroutine = StartCoroutine(DrawBoosters(boosterTime));
    }
    public void StopSpawnCoroutines()
    {
        StopCoroutine(BackgroundSpawningCoroutine);
        StopCoroutine(ObstacleSpawningCoroutine);
        StopCoroutine(GroundSpawningCoroutine);
        StopCoroutine(BoosterSpawningCoroutine);
    }

    #endregion
}
