using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Bishops_white : Board_manager
{
    private Image bishop_C1;
    private Image bishop_F1;

    void Awake(){
        Setup();

        bishop_C1 = boardFields[2];
        bishop_F1 = boardFields[5];
    }

    void Start(){

    }
}
