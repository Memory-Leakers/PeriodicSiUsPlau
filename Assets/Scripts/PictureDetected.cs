using UnityEngine;

public class PictureDetected : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;

    private void Start()
    {
        _particle.Stop();
    }

    public void OnPictureEnter()
    {

    }

    public void OnPictureExit()
    {

    }
}
