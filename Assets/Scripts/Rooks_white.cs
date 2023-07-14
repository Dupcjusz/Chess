using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Rooks_white : Board_manager
{
    private Image rook_A1;
    private Image rook_H1;

    void Awake(){
        Setup();

        rook_A1 = boardFields[0];
        rook_H1 = boardFields[7];
    }

    void Start(){
        
    }
}
