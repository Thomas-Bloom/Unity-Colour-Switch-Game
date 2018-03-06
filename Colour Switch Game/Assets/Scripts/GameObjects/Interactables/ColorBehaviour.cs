using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour {
    private ColourChange colourChange;
    public Color StartColour;
    private Color alphaColour;
    public string thisColour;

    void Start() {
        colourChange = FindObjectOfType<ColourChange>();
        alphaColour = StartColour;
        alphaColour.a = 0.3f;
    }

    private void Update() {
        if (colourChange.currentColour.Equals(thisColour)) {
            // Same colour as player
            print("same");
            gameObject.layer = 10;
            GetComponent<SpriteRenderer>().color = StartColour;
            //GetComponent<SpriteRenderer>().color = thisColor;
        }
        else {
            print("not same");
            GetComponent<SpriteRenderer>().color = alphaColour;
            gameObject.layer = 11;
            // Not same colour
            //thisColor.a = 0.5f;
            //GetComponent<SpriteRenderer>().color = thisColor;
        }
    }

}
