using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Bishops_black : Board_manager
{
    private Image bishop_C8;
    private Image bishop_F8;

    void Awake(){
        Setup();

        bishop_C8 = boardFields[58];
        bishop_F8 = boardFields[61];
    }

    void Start(){
    
    }
}
