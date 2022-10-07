using UnityEngine;

public class PlayParticlesOnEnable : MonoBehaviour
{
    private ParticleSystem _particles;
    
    private void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
        _particles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _particles.Play();
    }
}
