using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public Transform playerTransform;
    public Player playerScript;
    public Collider2D playerCollider;
    [Space]
    public Transform cameraTransform;
    public Transform objectsMenu;
    [Space]
    public GlowManager glowingMaterial;
    [Space]
    public AudioPlayerManager audioPlayer;
}
