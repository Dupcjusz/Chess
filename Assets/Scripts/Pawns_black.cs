using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Pawns_black : Board_manager
{
    private Image pawn_A7;
    private Image pawn_B7;
    private Image pawn_C7;
    private Image pawn_D7;
    private Image pawn_E7;
    private Image pawn_F7;
    private Image pawn_G7;
    private Image pawn_H7;

    void Awake(){
        Setup();

        pawn_A7 = boardFields[48];
        pawn_B7 = boardFields[49];
        pawn_C7 = boardFields[50];
        pawn_D7 = boardFields[51];
        pawn_E7 = boardFields[52];
        pawn_F7 = boardFields[53];
        pawn_G7 = boardFields[54];
        pawn_H7 = boardFields[55];
    }

    void Start(){

    }
}
