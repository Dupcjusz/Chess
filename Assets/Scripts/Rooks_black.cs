using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Rooks_black : Board_manager
{
    private Image rook_A8;
    private Image rook_H8;

    void Awake(){
        Setup();

        rook_A8 = boardFields[56];
        rook_H8 = boardFields[63];
    }

    void Start(){
        
    }
}
