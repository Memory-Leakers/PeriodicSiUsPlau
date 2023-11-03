using UnityEngine;

public class PictureDetected : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;
    
    DragObjectManager _dragObjectManager;

    private void Start()
    {
        _particle.Stop();

        if (GameObject.FindGameObjectWithTag("Picture Manager").TryGetComponent<DragObjectManager>(out _dragObjectManager))
        {
            _dragObjectManager.onPictureEnter += OnPictureEnter;
            _dragObjectManager.onPictureExit += OnPictureExit;
        }
    }

    private void OnPictureEnter()
    {
        Debug.Log("picture enter to select area");
        _particle.Play();
    }

    private void OnPictureExit()
    {
        Debug.Log("picture exit from select area");
        _particle.Stop();
    }
}
