using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryBox : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    public AudioClip _misteryBoxSFX;
    public AudioClip _misteryBoxSFX2;

    private bool _isOpen = false;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void ActivateBox()
    {
        if(!_isOpen)
        {
            _animator.SetTrigger("OpenBox");

            _audioSource.volume = 1;
            _audioSource.clip = _misteryBoxSFX;

            _isOpen = true;
        }
        else
        {
            _audioSource.clip = _misteryBoxSFX2;
            _audioSource.volume = 0.5f;
        }

        _audioSource.Play();
        //_audioSource.Pause();
        //_audioSource.Stop();
    }

   void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            ActivateBox();
        }
    }
}
