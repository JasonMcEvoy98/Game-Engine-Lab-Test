using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    private enum LightColours
    {
        Green, Yellow, Red
    }
    private LightColours myColour;
    public Renderer colourRenderer;
    
    private void Start()
    {
        myColour = (LightColours)Random.Range(0, 3);
        colourRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(ColourChange());
    }

    void Update()
    {
        if (myColour == LightColours.Green)
        {colourRenderer.material.color = Color.green;}
        if (myColour == LightColours.Yellow)
        {colourRenderer.material.color = Color.yellow; }
        if (myColour == LightColours.Red)
        { colourRenderer.material.color = Color.red; }
    }

    IEnumerator ColourChange()
    {
        
        if (myColour == LightColours.Yellow)
        {  yield return new WaitForSeconds(4); }
        else
        {  yield return new WaitForSeconds(Random.Range(5, 10)); }

        myColour++;

        if (myColour > LightColours.Red)
        { myColour = LightColours.Green; }

        StartCoroutine(ColourChange());
    }
}
