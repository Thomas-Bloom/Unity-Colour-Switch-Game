using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour {
    private ColourChange colourChange;
    public string thisColour;

    void Start() {
        colourChange = FindObjectOfType<ColourChange>();
    }

    private void Update() {
        if (colourChange.currentColour.Equals(thisColour)) {
            // Same colour as player
            print("same");
            //thisColor.a = 1f;
            //GetComponent<SpriteRenderer>().color = thisColor;
        }
        else {
            print("not same");
            // Not same colour
            //thisColor.a = 0.5f;
            //GetComponent<SpriteRenderer>().color = thisColor;
        }
    }

}
