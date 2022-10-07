using System.Collections;
using UnityEngine;

public class PlayerParticlesController : MonoBehaviour
{
    [SerializeField] private GameObject deathParticlesObject;
    [SerializeField] private GameObject impactParticlesObject;
    [SerializeField] private ParticleSystem walkParticles;
    [SerializeField] private float effectsSuppressionDuration = 0.1f;
    
    private bool _triggeredByJumpPad;

    private float _suppressTimer;
    
    public void PlayDeathParticles()
    {
        deathParticlesObject.SetActive(true);
    }

    public void PlayImpactParticles()
    {
        if (_triggeredByJumpPad) return;
        
        impactParticlesObject.SetActive(true);
    }

    public void PlayWalkParticles(bool isGrounded)
    {
        var emission = walkParticles.emission;

        emission.enabled = isGrounded;
    }

    public void TriggeredByJumpPad()
    {
        StartCoroutine(EffectSuppressionCooldown());
    }

    private IEnumerator EffectSuppressionCooldown()
    {
        _triggeredByJumpPad = true;
        yield return new WaitForSeconds(effectsSuppressionDuration);
        _triggeredByJumpPad = false;
    }
}
