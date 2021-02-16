using System.Collections;
using UnityEngine;

public class FlexModeManager : MonoBehaviour
{
    private ComponentsManager components;
    private GameStateManager gameState;
    private SpawningObjectsManager spawningObjects;
    private GamePreferencesManager gamePreferences;

    void Awake()
    {
        components = GetComponent<ComponentsManager>();
        gameState = GetComponent<GameStateManager>();
        spawningObjects = GetComponent<SpawningObjectsManager>();
        gamePreferences = GetComponent<GamePreferencesManager>();
    }

    public void ChangeObstaclesSolidness(bool isSolid)
    {
        components.playerCollider.isTrigger = !isSolid;
    }
    private void ChangeCoroutinesSpeed(float first, float second, float third, float fourth)
    {
        spawningObjects.StopSpawnCoroutines();
        spawningObjects.StartSpawnCoroutines(first, second, third, fourth);
    }

    public void StartFlexingForFixedTime(float time, float speedCoefficient, AudioClip clip)
    {
        if (!gameState.IsGameStopped) StartCoroutine(FlexMode(time, speedCoefficient, clip));
    }
    public void StopFlexingAfterDeath()
    {
        gameState.IsGameInFlexMode = false;
        components.glowingMaterial.StopGlowing();
        ChangeObstaclesSolidness(true);
        components.audioPlayer.StopSound(components.audioPlayer.flexModeSoundAudioSource);
        components.audioPlayer.ResumeSound(components.audioPlayer.backgroundSoundAudioSource);
    }
    private IEnumerator FlexMode(float time, float speedCoefficient, AudioClip clip)
    {
        spawningObjects.DrawBackgroundPart(6);
        spawningObjects.DrawObstacle(6);
        spawningObjects.DrawGroundPart(6);

        gameState.IsGameInFlexMode = true;
        ChangeObstaclesSolidness(false);
        components.audioPlayer.PauseSound(components.audioPlayer.backgroundSoundAudioSource);
        components.audioPlayer.PlaySound(clip, components.audioPlayer.flexModeSoundAudioSource, 1, false);
        components.playerRigidbody.AddForce(-transform.right * gamePreferences.gameSpeed, ForceMode2D.Force);
        components.playerRigidbody.AddForce(transform.right * gamePreferences.gameSpeed * speedCoefficient, ForceMode2D.Force);
        ChangeCoroutinesSpeed(
            gamePreferences.backgroundSpawningDelay / speedCoefficient,
            gamePreferences.obstacleSpawningDelay / speedCoefficient,
            gamePreferences.groundSpawningDelay / speedCoefficient,
            gamePreferences.boosterSpawningDelay / speedCoefficient
            );
        components.glowingMaterial.StartGlowing(speedCoefficient);

        yield return new WaitForSeconds(time);

        gameState.IsGameInFlexMode = false;
        components.audioPlayer.StopSound(components.audioPlayer.flexModeSoundAudioSource);
        components.glowingMaterial.StopGlowing();
        components.audioPlayer.ResumeSound(components.audioPlayer.backgroundSoundAudioSource);
        components.playerRigidbody.AddForce(-transform.right * gamePreferences.gameSpeed * speedCoefficient, ForceMode2D.Force);
        components.playerRigidbody.AddForce(transform.right * gamePreferences.gameSpeed, ForceMode2D.Force);
        ChangeCoroutinesSpeed(
            gamePreferences.backgroundSpawningDelay,
            gamePreferences.obstacleSpawningDelay,
            gamePreferences.groundSpawningDelay,
            gamePreferences.boosterSpawningDelay
            );

        yield return new WaitForSeconds(2f);

        if (!gameState.IsGameInFlexMode) ChangeObstaclesSolidness(true);
    }
}
