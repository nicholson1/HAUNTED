using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SoundManager : MonoBehaviour
{

    public AudioSource Music;
    public AudioSource Sound;
    public AudioSource Loop;
    public AudioSource Pencil;
    public AudioSource Eraser;


    public AudioClip[] musics;
    public AudioClip[] sounds;
    public AudioClip[] loops;

    [YarnCommand("PlaySound")]
    public void PlaySound(string sound)
    {
        AudioClip a = null;
        float scale = 1;

        switch (sound)
        {
            case "page":
                a = sounds[0];
                break;
            case "doorcreak":
                a = sounds[1];
                break;
            case "floorcreak":
                a = sounds[2];
                break;
            case "footsteps":
                a = sounds[3];
                break;
            case "puddle":
                a = sounds[4];
                break;
        }
        Sound.PlayOneShot(a, scale);
    }
    [YarnCommand("PlayLoop")]
    public void PlayPool(string loop)
    {
        AudioClip a = null;
        float scale = 1;

        switch (loop)
        {
            case "talk":
                a = loops[0];
                break;
            case "drip":
                a = loops[1];
                break;
            case "swoosh":
                a = loops[3];
                break;
            
            case "none":
                scale = 0;
                Loop.Stop();
                break;
            
        }
        Loop.clip = a;
        Loop.volume = scale;
        Loop.Play();
        
    }
    
    [YarnCommand("PlayMusic")]
    public void PlayMusic(string music)
    {
        AudioClip a = null;
        float scale = .1f;

        switch (music)
        {
            case "scene1":
                a = musics[0];
                break;
            case "scene2":
                a = musics[1];
                break;
            case "scene3":
                a = musics[2];
                break;
            case "scene4":
                a = musics[3];
                break;
            case "scene5":
                a = musics[4];
                break;
            case "scene6b":
                a = musics[5];
                break;
            case "scene6a":
                a = musics[6];
                break;
            case "none":
                a = null;
                scale = 0;
                Music.Stop();
                break;
        }

        Music.clip = a;
        Music.volume = scale;
        Music.Play();
    }

    public void TogglePencilSound(bool play)
    {
        if (play)
        {
            Pencil.Play();
        }
        else
        {
            //Pencil.PlayOneShot();
            Pencil.Pause();
        }
    }
    public void ToggleEraserSound(bool play)
    {
        if (play)
        {
            Eraser.Play();
        }
        else
        {
            Eraser.Pause();
        }
    }
    
}
