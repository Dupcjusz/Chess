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
    private int i, n, j = 0;
    private string clickedField;
    private bool wasClicked = true;
    protected string[] piecesInfo = new string[64];
    private string[] boardFieldsInfo = new string[64];
    private string[] piecesName = new string[12];
    protected Image[] boardFields;
    private GameObject fieldsParent;
    public Sprite[] pieceImgWhite = new Sprite[12];
    public Sprite[] pieceImgBlack = new Sprite [12];
    public Sprite circleBlack;
    

    void Awake(){
        Setup();
        //boardFields = new Image[8, 8];

        /*for(i = 0; i < 8; i++){
            for(n = 0; n < 8; n++){
                boardFields[i, n] = fieldsParent.GetComponentsInChildren<Image>()[i, n];
                Debug.Log($"{boardFields[i, n]} = {i}, {n}");  
            }      
        }*/

//
        piecesInfo[56] = "rook_blackA8";
        boardFields[56].sprite = pieceImgBlack[0];
        piecesInfo[63] = "rook_blackH8";
        boardFields[63].sprite = pieceImgBlack[0];
        piecesInfo[57] = "knight_blackB8";
        boardFields[57].sprite = pieceImgBlack[1];
        piecesInfo[62] = "knight_blackG8";
        boardFields[62].sprite = pieceImgBlack[1];
        piecesInfo[58] = "bishop_blackC8";
        boardFields[58].sprite = pieceImgBlack[2];
        piecesInfo[61] = "bishop_blackF8";
        boardFields[61].sprite = pieceImgBlack[2];
        piecesInfo[59] = "queen_blackD8";
        boardFields[59].sprite = pieceImgBlack[3];
        piecesInfo[60] = "king_blackE8";
        boardFields[60].sprite = pieceImgBlack[4];

        piecesInfo[0] = "rook_whiteA1";
        boardFields[0].sprite = pieceImgWhite[0];
        piecesInfo[7] = "rook_whiteH1";
        boardFields[7].sprite = pieceImgWhite[0];
        piecesInfo[1] = "knight_whiteB2";
        boardFields[1].sprite = pieceImgWhite[1];
        piecesInfo[6] = "knight_whiteG1";
        boardFields[6].sprite = pieceImgWhite[1];
        piecesInfo[2] = "bishop_whiteC1";
        boardFields[2].sprite = pieceImgWhite[2];
        piecesInfo[5] = "bishop_whiteF1";
        boardFields[5].sprite = pieceImgWhite[2];
        piecesInfo[3] = "queen_whiteD1";
        boardFields[3].sprite = pieceImgWhite[3];
        piecesInfo[4] = "king_whiteE1";
        boardFields[4].sprite = pieceImgWhite[4];

            piecesInfo[48] = "pawn_blackA7";
            boardFields[48].sprite = pieceImgBlack[5];
            piecesInfo[49] = "pawn_blackB7";
            boardFields[49].sprite = pieceImgBlack[5];
            piecesInfo[50] = "pawn_blackC7";
            boardFields[50].sprite = pieceImgBlack[5];
            piecesInfo[51] = "pawn_blackD7";
            boardFields[51].sprite = pieceImgBlack[5];
            piecesInfo[52] = "pawn_blackE7";
            boardFields[52].sprite = pieceImgBlack[5];
            piecesInfo[53] = "pawn_blackF7";
            boardFields[53].sprite = pieceImgBlack[5];
            piecesInfo[54] = "pawn_blackG7";
            boardFields[54].sprite = pieceImgBlack[5];
            piecesInfo[55] = "pawn_blackH7";
            boardFields[55].sprite = pieceImgBlack[5];
        
            piecesInfo[8] = "pawn_whiteA2";
            boardFields[8].sprite = pieceImgWhite[5];
            piecesInfo[9] = "pawn_whiteB2";
            boardFields[9].sprite = pieceImgWhite[5];
            piecesInfo[10] = "pawn_whiteC2";
            boardFields[10].sprite = pieceImgWhite[5];
            piecesInfo[11] = "pawn_whiteD2";
            boardFields[11].sprite = pieceImgWhite[5];
            piecesInfo[12] = "pawn_whiteE2";
            boardFields[12].sprite = pieceImgWhite[5];
            piecesInfo[13] = "pawn_whiteF2";
            boardFields[13].sprite = pieceImgWhite[5];
            piecesInfo[14] = "pawn_whiteG2";
            boardFields[14].sprite = pieceImgWhite[5];
            piecesInfo[15] = "pawn_whiteH2";
            boardFields[15].sprite = pieceImgWhite[5];
        
        for(i = 16; i <= 47; i++){
            piecesInfo[i] = "";
            boardFields[i].sprite = pieceImgWhite[11];
        }    
 

    boardFieldsInfo[0] = "A1";
    boardFieldsInfo[1] = "B1";
    boardFieldsInfo[2] = "C1";
    boardFieldsInfo[3] = "D1";
    boardFieldsInfo[4] = "E1";
    boardFieldsInfo[5] = "F1";
    boardFieldsInfo[6] = "G1";
    boardFieldsInfo[7] = "H1";
    boardFieldsInfo[8] = "A2";
    boardFieldsInfo[9] = "B2";
    boardFieldsInfo[10] = "C2";
    boardFieldsInfo[11] = "D2";
    boardFieldsInfo[12] = "E2";
    boardFieldsInfo[13] = "F2";
    boardFieldsInfo[14] = "G2";
    boardFieldsInfo[15] = "H2";
    boardFieldsInfo[16] = "A3";
    boardFieldsInfo[17] = "B3";
    boardFieldsInfo[18] = "C3";
    boardFieldsInfo[19] = "D3";
    boardFieldsInfo[20] = "E3";
    boardFieldsInfo[21] = "F3";
    boardFieldsInfo[22] = "G3";
    boardFieldsInfo[23] = "H3";
    boardFieldsInfo[24] = "A4";
    boardFieldsInfo[25] = "B4";
    boardFieldsInfo[26] = "C4";
    boardFieldsInfo[27] = "D4";
    boardFieldsInfo[28] = "E4";
    boardFieldsInfo[29] = "F4";
    boardFieldsInfo[30] = "G4";
    boardFieldsInfo[31] = "H4";
    boardFieldsInfo[32] = "A5";
    boardFieldsInfo[33] = "B5";
    boardFieldsInfo[34] = "C5";
    boardFieldsInfo[35] = "D5";
    boardFieldsInfo[36] = "E5";
    boardFieldsInfo[37] = "F5";
    boardFieldsInfo[38] = "G5";
    boardFieldsInfo[39] = "H5";
    boardFieldsInfo[40] = "A6";
    boardFieldsInfo[41] = "B6";
    boardFieldsInfo[42] = "C6";
    boardFieldsInfo[43] = "D6";
    boardFieldsInfo[44] = "E6";
    boardFieldsInfo[45] = "F6";
    boardFieldsInfo[46] = "G6";
    boardFieldsInfo[47] = "H6";
    boardFieldsInfo[48] = "A7";
    boardFieldsInfo[49] = "B7";
    boardFieldsInfo[50] = "C7";
    boardFieldsInfo[51] = "D7";
    boardFieldsInfo[52] = "E7";
    boardFieldsInfo[53] = "F7";
    boardFieldsInfo[54] = "G7";
    boardFieldsInfo[55] = "H7";
    boardFieldsInfo[56] = "A8";
    boardFieldsInfo[57] = "B8";
    boardFieldsInfo[58] = "C8";
    boardFieldsInfo[59] = "D8";
    boardFieldsInfo[60] = "E8";
    boardFieldsInfo[61] = "F8";
    boardFieldsInfo[62] = "G8";
    boardFieldsInfo[63] = "H8";

    piecesName[0] = "rook_white";
    piecesName[1] = "knight_white";
    piecesName[2] = "bishop_white";
    piecesName[3] = "queen_white";
    piecesName[4] = "king_white";
    piecesName[5] = "pawn_white";
    piecesName[6] = "rook_black";
    piecesName[7] = "knight_black";
    piecesName[8] = "bishop_black";
    piecesName[9] = "queen_black";
    piecesName[10] = "king_black";
    piecesName[11] = "pawn_black";
//
    }

    void Update()
    {
        //Debug.Log("chuj");
        if(Input.GetMouseButtonDown(0)){
            wasClicked = true;
            Debug.Log("Pressed left click, casting ray");
            CastRay();
        }   
    }

    protected void CastRay(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
        if(hit){
            clickedField = hit.collider.gameObject.name;
            CheckingClickedField();
        }
    }

    protected void Setup(){
        fieldsParent = GameObject.Find("Canvas/Board/Fields");
        boardFields = new Image[fieldsParent.transform.childCount];

        for(i = 0; i < fieldsParent.transform.childCount; i++){
            boardFields[i] = fieldsParent.GetComponentsInChildren<Image>()[i];
            //Debug.Log($"{boardFields[i]} = {i}");        
        }
    }

    protected void CheckingClickedField(){
        for(i = 0; i < 64; i++){
            if(clickedField == boardFieldsInfo[i]){
                if(piecesInfo[i] == ""){
                    Debug.Log("Empty field!");
                }else{
                    for(n = 0, j = 0; n < 12; n++, j++){
                        if(piecesInfo[i].Contains(piecesName[j])){
                            Debug.Log(piecesName[j]);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
