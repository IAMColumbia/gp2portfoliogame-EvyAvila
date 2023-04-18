using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] //checking to see if objects are inside the containment
    private List<GameObject> disguiseUI;

    public MainPlayerController mainPlayer;

    private void Awake()
    {
        disguiseUI= new List<GameObject>();
        SetUIImages();
    }

    private void Start()
    {
        foreach(var v in disguiseUI)
        {
            v.gameObject.SetActive(false);
        }    
    }


    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void SetUIImages()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            disguiseUI.Add(transform.GetChild(i).gameObject); //From https://www.youtube.com/watch?v=RfwsbRSc2Fg&t=89s
        }

    }
    

    private void UpdateUI()
    {
        for(int i = 0; i < disguiseUI.Count; i++)
        {
            if (mainPlayer.hasDisguise.Find(x => x.name == disguiseUI[i].name))
            {
                disguiseUI[i].gameObject.SetActive(true);
            }
        }    
        
    }
}
