using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


//Not my code - Jeff Meyers
public enum KeyPlayMode { PlayOnKey, PlayOneShotOnKey, LoopOnKey, PlayOnStart, PlayOnAwake, LoopOnStart, LoopOnAwake }
public enum KeyPriority { Normal, High, HighWithSkip }

public enum Screen { Menu, Game, Loss, Won}

public class Audio : MonoBehaviour
{
    public AudioClip Clip;
    public AudioSource Source;
    public KeyCode Key;

    public KeyPlayMode keyPlayMode;
    public KeyPriority keyPriority;

    public Screen screen;

    private bool isPaused;

    private MainPlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("RobTheBlob").GetComponent<MainPlayerController>();
       
        this.Source.clip = Clip;
        this.Source.name = Clip.name;
        switch (keyPlayMode)
        {
            case KeyPlayMode.PlayOnStart:
                Source.PlayOneShot(Clip);
                break;
            case KeyPlayMode.LoopOnStart:
                Source.loop = true;
                Source.Play();
                break;
        }
    }

    void Awake()
    {
        this.Source = this.gameObject.AddComponent<AudioSource>();
        if (this.keyPriority == KeyPriority.High)
        {
            this.Source.priority = 1;

        }
        if (this.keyPriority == KeyPriority.HighWithSkip)
        {
            this.Source.priority = 1;
            this.Source.bypassEffects = true;
            this.Source.bypassListenerEffects = true;
            this.Source.bypassReverbZones = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (screen)
        {
            case Screen.Game:
            case Screen.Menu:
                
                if (keyPlayMode == KeyPlayMode.LoopOnKey && player.gameState == MainPlayerController.ConditionState.Active)
                {
                    Source.loop = true;
                    Source.clip = Clip;
                    if (Input.GetKeyDown(Key))
                    {
                        if (isPaused)
                        {
                            Source.UnPause();
                            this.isPaused = false;
                        }
                        else
                            Source.Play();
                    }
                }
                else if(player.gameState == MainPlayerController.ConditionState.Winner || player.gameState == MainPlayerController.ConditionState.Caught)
                {
                    Source.Stop();
                }
                
                break;
            case Screen.Loss:
            case Screen.Won:
               
                
                keyPlayMode = KeyPlayMode.PlayOnStart;
                break;
        }


        
    }
}
