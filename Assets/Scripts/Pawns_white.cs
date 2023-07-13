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
    private GameObject pawn_A2;
    private GameObject pawn_B2;
    private GameObject pawn_C2;
    private GameObject pawn_D2;
    private GameObject pawn_E2;
    private GameObject pawn_F2;
    private GameObject pawn_G2;
    private GameObject pawn_H2;

    void Awake(){
        pawn_A2 = GameObject.Find("Canvas/Board/Pieces_white/PawnA2");
        pawn_B2 = GameObject.Find("Canvas/Board/Pieces_white/PawnB2");
        pawn_C2 = GameObject.Find("Canvas/Board/Pieces_white/PawnC2");
        pawn_D2 = GameObject.Find("Canvas/Board/Pieces_white/PawnD2");
        pawn_E2 = GameObject.Find("Canvas/Board/Pieces_white/PawnE2");
        pawn_F2 = GameObject.Find("Canvas/Board/Pieces_white/PawnF2");
        pawn_G2 = GameObject.Find("Canvas/Board/Pieces_white/PawnG2");
        pawn_H2 = GameObject.Find("Canvas/Board/Pieces_white/PawnH2");
        Setup();
    }

    void Start(){
        
    }
}
