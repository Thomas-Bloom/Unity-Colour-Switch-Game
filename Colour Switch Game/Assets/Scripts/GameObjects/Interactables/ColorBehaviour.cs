using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour {
    private ColourChange colourChange;
    public Color StartColour;
    private Color alphaColour;
    public string thisColour;
    public GameObject insideCollider;
    private PlayerController player;

    void Start() {
        player = FindObjectOfType<PlayerController>();
        colourChange = FindObjectOfType<ColourChange>();
        alphaColour = StartColour;
        alphaColour.a = 0.3f;
    }

    private void Update() {
        // If same colour as the player
        if (colourChange.currentColour.Equals(thisColour)) {
            gameObject.layer = 10;
            GetComponent<SpriteRenderer>().color = StartColour;
            insideCollider.SetActive(true);
        }
        // If not same colour as player
        else {
            GetComponent<SpriteRenderer>().color = alphaColour;
            gameObject.layer = 11;
            insideCollider.SetActive(false);
        }
    }

}
