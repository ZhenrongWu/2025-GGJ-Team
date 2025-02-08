using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class Initiate
{
    private static bool areWeFading = false;

    //Create Fader object and assing the fade scripts and assign all the variables
    public static void Fade(string scene, Color col, float multiplier)
    {
        if (areWeFading)
            // Debug.Log("Already Fading");
            return;

        var init = new GameObject();
        init.name = "Fader";
        var myCanvas = init.AddComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        init.AddComponent<Fader>();
        init.AddComponent<CanvasGroup>();
        init.AddComponent<Image>();

        var scr = init.GetComponent<Fader>();
        scr.fadeDamp  = multiplier;
        scr.fadeScene = scene;
        scr.fadeColor = col;
        scr.start     = true;
        areWeFading   = true;
        scr.InitiateFader();
    }

    public static void DoneFading()
    {
        areWeFading = false;
    }
}