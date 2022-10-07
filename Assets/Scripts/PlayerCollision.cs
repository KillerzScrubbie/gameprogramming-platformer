using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private PlayerParticlesController particlesController;

    private Collider2D _playerCollider;
    private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
    }

    public void Bounce(float jumpPadForce, float jumpTimeSleep)
    {
        playerController.Jump(jumpPadForce, jumpTimeSleep);
    }

    public void SuppressNormalJumpEffects()
    {
        audioController.MuteAudioSource();
        particlesController.TriggeredByJumpPad();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Collectibles collectible))
        {
            var collectibleType = collectible.GetCollectibleInfoOnContact();

            switch (collectibleType)
            {
                case CollectibleType.DoubleJump:
                    playerController.EnableDoubleJump();
                    break;
                case CollectibleType.RefillHealth:
                case CollectibleType.RefillEnergy:
                case CollectibleType.RefillDash:
                default:
                    break;
            }
        }

        if (!_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard"))) return;
        
        playerController.TakeDamage();
        particlesController.PlayDeathParticles();
    }
}
