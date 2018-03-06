using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourChange : MonoBehaviour {

    public Color color0, color1, color2;
    public Image[] colorImages;
    public string currentColour;
    public int item = 1;
    private int min = 0;
    private int max = 2;

    private void Start() {

    }

    void Update() {
        colorImages[0].GetComponent<Image>().color = color0;
        colorImages[1].GetComponent<Image>().color = color1;
        colorImages[2].GetComponent<Image>().color = color2;

        // SWITCH COLORS
        GetComponent<SpriteRenderer>().color = colorImages[item].color;

        // E ->>>>
        if (Input.GetKeyDown(KeyCode.E)) {
            item++;
            if (item > max)
                item = min;
        }

        // Q <<<<-
        if (Input.GetKeyDown(KeyCode.Q)) {
            item--;
            if (item < min)
                item = max;
        }


        // Update UI
        if (item == 0) {
            currentColour = "Red";
            color0.a = 1f;
            color1.a = 0.3f;
            color2.a = 0.3f;
        }

        if (item == 1) {
            currentColour = "Green";
            color0.a = 0.3f;
            color1.a = 1f;
            color2.a = 0.3f;
        }

        if (item == 2) {
            currentColour = "Blue";
            color0.a = 0.3f;
            color1.a = 0.3f;
            color2.a = 1f;
        }

    }
}
