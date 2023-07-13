using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Board_manager : MonoBehaviour
{
    private int i, n;
    protected Vector2 defaultPos = new Vector2(0, 0);
    public string[,] piecesInfo = new string[8, 8];
    public Image[,] boardFields = new Image[8, 8];
    public Sprite[] pieceImgWhite = new Sprite[6];
    public Sprite[] pieceImgBlack = new Sprite [6];
    

    void Awake(){
        //Setup();

        piecesInfo[0, 0] = "rook_black";
        piecesInfo[0, 7] = "rook_black";
        piecesInfo[0, 1] = "knight_black";
        piecesInfo[0, 6] = "knight_black";
        piecesInfo[0, 2] = "bishop_black";
        piecesInfo[0, 5] = "bishop_black";
        piecesInfo[0, 3] = "queen_black";
        piecesInfo[0, 4] = "king_ black";

        piecesInfo[7, 0] = "rook_white";
        piecesInfo[7, 7] = "rook_white";
        piecesInfo[7, 1] = "knight_white";
        piecesInfo[7, 6] = "knight_white";
        piecesInfo[7, 2] = "bishop_white";
        piecesInfo[7, 5] = "bishop_white";
        piecesInfo[7, 3] = "queen_white";
        piecesInfo[7, 4] = "king_ white";

        for(i = 0; i <= 7; i++){
            piecesInfo[1, i] = "pawn_black";
        }
        for(i = 0; i <= 7; i++){
            piecesInfo[6, i] = "pawn_white";
        }
        for(i = 2; i <= 5; i++){
            for(n = 0; n <= 7; n++){
                piecesInfo[i, n] = "";
            }
        }     
    }

    protected void Setup(){

    }
}
