using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    public static event Action<Renderer, Color> HoveringObject;

    private Renderer myRender;
    [SerializeField] private Color c;
    private void Start()
    {
        myRender = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {
        HoveringObject(myRender, c);
    }

    void OnMouseExit()
    {
        HoveringObject(null, c);

    }
}
