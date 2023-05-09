using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIBar : MonoBehaviour
{
    //this class be an observer of diguisetime from player
    private MainPlayerController player;

    //[SerializeField]
    //float CountDown;

    float sizeScale;

    private float orgScale;

    public RobState checkState;

    private RobState objectState;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("RobTheBlob").GetComponent<MainPlayerController>();
        objectState = checkState;
        orgScale = transform.localScale.x;
        
    }

   
    // Update is called once per frame
    void Update()
    {
        if(objectState == player.state)
        {
            if (transform.localScale.x > 0.0f)
            {
                this.transform.localScale -= new Vector3(1, 0, 0) * Time.deltaTime * player.DisguisePercent / 60;
            }
           
        }
        else 
        {
            this.transform.localScale = new Vector3(orgScale, orgScale, orgScale);
        }
    }

    
      
    

    


}
