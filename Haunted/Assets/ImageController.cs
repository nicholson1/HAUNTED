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
    //friends
    //8, 17, 40, 70
    
    //rooms
    //bowl, kidbed, bedroom, attic, porch, kitchen, basement, livingroom, housefar, mirror, neighborhood
    

    [YarnCommand("NextBackground")]
    public void NextBackground(string place)
    {
        //many of these
        
    }
    [YarnCommand("NextPlayer")]
    public void NextPlayer(string age)
    {
        //6 player portrait at different ages
        
    }
    [YarnCommand("NextNPC")]
    public void NextNPC(string npc)
    {
        //4 of each of the 3 friends, 2 son, 2 mom, friend kid
    }
    
    IEnumerator FadeTo(float aValue, float aTime, Sprite nextImage)
    {
        float alpha = BackgroundImage.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
            BackgroundImage.material.color = newColor;
            yield return null;
        }
    }
    
    
    
}
