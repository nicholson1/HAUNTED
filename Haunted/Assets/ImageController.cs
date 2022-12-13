using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ImageController : MonoBehaviour
{
    public Sprite[] BackgroundImages;
    public Image BackgroundImage;
    public Sprite[] PlayerImages;

    public Image PlayerImage;
    public Sprite[] NpcImages;
    public Image NPCImage;

    private int index = 0;
    
    //nameing convention for transitions "character" + "age" ie: del8, ash17, jul24, riv8, mom1, mom2, kid1, kid2
    //PC
    //8, 13, 17, 24, 40, 70
    //friends ash, jul, riv
    //8, 17, 40, 70
    
    //rooms
    //bowl, kidbed, bedroom, attic, porch, kitchen, basement, livingroom, housefar, mirror, neighborhood

    //none
    private float Playertimer = 12;
    private int playerCounter = 0;
    private float backtimer = 9;

    private int BackgroundCounter = 0;
    private float npctimer = 7;

    
    private int npcCounter = 0;

    public bool CycleImages = false;
    public void Update()
    {
        if (CycleImages)
        {
            Playertimer -= Time.deltaTime;
            npctimer  -= Time.deltaTime;
            backtimer  -= Time.deltaTime;

            if (Playertimer < 0)
            {
                playerCounter += 1;
                if (playerCounter > PlayerImages.Length - 1)
                {
                    playerCounter = 0;
                }
                SwapImages(PlayerImage, PlayerImages[playerCounter] ,1.5f);

                Playertimer = 12;

            }
            if (backtimer < 0)
            {
                BackgroundCounter += 1;
                if (BackgroundCounter > BackgroundImages.Length - 1)
                {
                    BackgroundCounter= 0;
                }
                SwapImages(BackgroundImage, BackgroundImages[BackgroundCounter] ,2f);
                backtimer = 9;
            }
            if (npctimer < 0)
            {
                npcCounter += 1;
                if (npcCounter > NpcImages.Length - 1)
                {
                    npcCounter= 0;
                }
                SwapImages(NPCImage, NpcImages[npcCounter] ,1f);
                npctimer = 7;
            }
        }
        

    }
    
    
    


    [YarnCommand("NextBackground")]
    public void NextBackground(string place)
    {
        
        //timer = 2
        //many of these
        
        Sprite i = BackgroundImage.sprite;
        
        switch (place)
        {
            case "housefar":
                i = BackgroundImages[0];
                break;
            case "neighborhood":
                i = BackgroundImages[1];
                break;
            case "porch":
                i = BackgroundImages[2];
                break;
            case "mirror":
                i = BackgroundImages[3];
                break;
            case "bowl":
                i = BackgroundImages[4];
                break;
            case "livingroom":
                i = BackgroundImages[5];
                break;
            case "kitchen":
                i = BackgroundImages[6];
                break;
            case "attic":
                i = BackgroundImages[7];
                break;
            case "kidbed":
                i = BackgroundImages[8];
                break;
            case "bedroom":
                i = BackgroundImages[9];
                break;
            case "basement":
                i = BackgroundImages[10];
                break;
            case "none":
                i = null;
                break;
        }
        
        SwapImages(BackgroundImage, i ,2f);
        
        
    }
    [YarnCommand("NextPlayer")]
    public void NextPlayer(string age)
    {
        //time =1
        //PC
        //8, 13, 17, 24, 40, 70

        Sprite i = PlayerImage.sprite;

        switch (age)
        {
            case "del8":
                i = PlayerImages[0];
                break;
            case "del13":
                i = PlayerImages[1];
                break;
            case "del17":
                i = PlayerImages[2];
                break;
            case "del24":
                i = PlayerImages[3];
                break;
            case "del40":
                i = PlayerImages[4];
                break;
            case "del70":
                i = PlayerImages[5];
                break;
            case "none":
                i = null;
                break;
                
        }

        SwapImages(PlayerImage, i ,1.5f);
    }
    [YarnCommand("NextNPC")]
    public void NextNPC(string npc)
    {
        //timer = .5
        //4 of each of the 3 friends, 2 son, 2 mom, friend kid, kida, kidj, kidr
        //friends ash, jul, riv
        //8, 17, 40, 70
        
        Sprite i = NPCImage.sprite;

        switch (npc)
        {
            case "ash8":
                i = NpcImages[0];
                break;
            case "ash17":
                i = NpcImages[1];
                break;
            case "ash40":
                i = NpcImages[2];
                break;
            case "ash70":
                i = NpcImages[3];
                break;
            case "riv8":
                i = NpcImages[4];
                break;
            case "riv17":
                i = NpcImages[5];
                break;
            case "riv40":
                i = NpcImages[6];
                break;
            case "riv70":
                i = NpcImages[7];
                break;
            case "jul8":
                i = NpcImages[8];
                break;
            case "jul17":
                i = NpcImages[9];
                break;
            case "jul40":
                i = NpcImages[10];
                break;
            case "jul70":
                i = NpcImages[11];
                break;
            case "son1":
                i = NpcImages[12];
                break;
            case "son2":
                i = NpcImages[13];
                break;
            case "mom1":
                i = NpcImages[14];
                break;
            case "mom2":
                i = NpcImages[15];
                break;
            case "kida":
                i = NpcImages[16];
                break;
            case "kidj":
                i = NpcImages[17];
                break;
            case "kidr":
                i = NpcImages[18];
                break;
            case "none":
                i = null;
                break;
        }

        SwapImages(NPCImage, i ,.5f);
    }

    public void SwapImages(Image image, Sprite newImage, float time)
    {
        StartCoroutine(SwitchImage(image,newImage, time));
    }
    
    IEnumerator SwitchImage(Image i, Sprite nextImage, float aTime )
    {
        float alpha = i.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,0,t));
            i.color = newColor;
            yield return null;
        }

        if (nextImage != null)
        {
            alpha = i.color.a;
            i.sprite = nextImage;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,1,t));
                i.color = newColor;
                yield return null;
            }
        }
       

    }
    
    
    
}
