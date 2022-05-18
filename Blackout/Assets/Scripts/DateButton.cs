using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateButton : MonoBehaviour
{
    //En knapp som när man trycker på en vald panel så öppnas en större panel med mer info på.
    //
    //Leta up paneler och skriv ut  kvälls grund info på dem t.ex (__:__:__Date, _,_ promille)
    //
    // Find.Button.Namn.text. print från listan på json. 
    // if(button pressed){       ........Poppa upp en större panel som har all info på sig ifrån kvällen.
    // spawn panel(med resterande av kvällens info)
    // add scrollbar på panel som används om de varit en längre kväll. 
    //Skrivut all info ifrån kvällen;
    // }
    public Canvas canvas;
    public bool popup = false;
    public void popupD()
    {
        if (popup == false)
        {
            popup = true;
            canvas.enabled = true;
        }
        else if (popup == true)
        {
            popup = false;
            canvas.enabled = false;
        }

    }




}
