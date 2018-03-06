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
        // If same colour as the player
        if (colourChange.currentColour.Equals(thisColour)) {
            gameObject.layer = 10;
            GetComponent<SpriteRenderer>().color = StartColour;
        }
        // If not same colour as player
        else {
            GetComponent<SpriteRenderer>().color = alphaColour;
            gameObject.layer = 11;
        }
    }

}
