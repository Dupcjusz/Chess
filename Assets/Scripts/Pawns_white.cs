using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Pawns_white : Board_manager
{
    private Image pawn_A2;
    private Image pawn_B2;
    private Image pawn_C2;
    private Image pawn_D2;
    private Image pawn_E2;
    private Image pawn_F2;
    private Image pawn_G2;
    private Image pawn_H2;

    void Awake(){
        Setup();

        pawn_A2 = boardFields[8];
        pawn_B2 = boardFields[9];
        pawn_C2 = boardFields[10];
        pawn_D2 = boardFields[11];
        pawn_E2 = boardFields[12];
        pawn_F2 = boardFields[13];
        pawn_G2 = boardFields[14];
        pawn_H2 = boardFields[15];
    }

    void Start(){
        
    }
}
