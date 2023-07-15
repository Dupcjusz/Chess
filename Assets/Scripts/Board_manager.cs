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
    private int i, n, j, l;
    private string clickedField;
    private string clickedPiece;
    private int clickedPos;
    private bool wasClicked = false, alrClicked = false;
    private bool[] firstMove = new bool[16];
    protected string[] piecesInfo = new string[64]; //what is on field
    private string[] boardFieldsInfo = new string[64]; //name of the fields
    private string[] piecesName = new string[12]; //pieces name
    protected Image[] boardFields;
    private GameObject fieldsParent;
    public Sprite[] pieceImgWhite = new Sprite[12];
    public Sprite[] pieceImgBlack = new Sprite [12];
    public Sprite circleBlack;
    

    void Awake(){
        Setup();
    }

    protected void test(){
        Debug.Log("agg");
    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(!wasClicked){
                wasClicked = true;
                Debug.Log("Pressed left click, casting ray");
                CastRay();
            }
        }   
    }

    protected void CastRay(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
        if(hit){
            clickedField = hit.collider.gameObject.name;
            CheckingClickedField();    
        }else{
            wasClicked = false;
        }
    }

    protected void Setup(){
        fieldsParent = GameObject.Find("Canvas/Board/Fields");
        boardFields = new Image[fieldsParent.transform.childCount];

        for(i = 0; i < fieldsParent.transform.childCount; i++){
            boardFields[i] = fieldsParent.GetComponentsInChildren<Image>()[i];      
        }

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

        for(i = 0; i < 16; i++){
            firstMove[i] = true;
        }
    }

    protected void CheckingClickedField(){
        for(i = 0; i < 64; i++){
            if(clickedField == boardFieldsInfo[i]){
                if(piecesInfo[i] == ""){
                    if(alrClicked){
                        CancelMoving();
                    }
                    Debug.Log("Empty field!");
                    wasClicked = false;
                    break;
                }else{
                    for(n = 0, j = 0; n < 12; n++, j++){
                        if(piecesInfo[i] == "MoveOptionA"){
                            if(clickedPiece == "pawn_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                boardFields[clickedPos + 8].sprite = pieceImgWhite[5];
                                if(piecesInfo[clickedPos] == "pawn_whiteA2"){
                                    if(firstMove[0]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[0] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_whiteB2"){
                                    if(firstMove[1]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[1] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_whiteC2"){
                                    if(firstMove[2]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[2] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_whiteD2"){
                                    if(firstMove[3]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[3] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_whiteE2"){
                                    if(firstMove[4]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[4] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_whiteF2"){
                                    if(firstMove[5]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[5] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_whiteG2"){
                                    if(firstMove[6]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[6] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_whiteH2"){
                                    if(firstMove[7]){
                                        if(piecesInfo[clickedPos + 16] == "MoveOptionB"){
                                            boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                                            piecesInfo[clickedPos + 16] = "";
                                        }
                                        firstMove[7] = false;
                                    }   
                                }
                                piecesInfo[clickedPos] = "";
                                piecesInfo[clickedPos + 8] = clickedPiece;
                            }else if(clickedPiece == "pawn_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                boardFields[clickedPos - 8].sprite = pieceImgBlack[5];
                                if(piecesInfo[clickedPos] == "pawn_blackA7"){
                                    if(firstMove[8]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[8] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_blackB7"){
                                    if(firstMove[9]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[9] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_blackC7"){
                                    if(firstMove[10]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[10] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_blackD7"){
                                    if(firstMove[11]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[11] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_blackE7"){
                                    if(firstMove[12]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[12] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_blackF7"){
                                    if(firstMove[13]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[13] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_blackG7"){
                                    if(firstMove[14]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[14] = false;
                                    }   
                                }
                                if(piecesInfo[clickedPos] == "pawn_blackH7"){
                                    if(firstMove[15]){
                                        if(piecesInfo[clickedPos - 16] == "MoveOptionB"){
                                            boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 16] = "";
                                        }
                                        firstMove[15] = false;
                                    }   
                                }
                                piecesInfo[clickedPos] = "";
                                piecesInfo[clickedPos - 8] = clickedPiece;
                            }else if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos + 6].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos + 6] = clickedPiece;
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                    boardFields[clickedPos + 10].sprite = pieceImgWhite[11];
                                    piecesInfo[clickedPos + 10] = "";
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionB"){
                            if(clickedPiece == "pawn_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                boardFields[clickedPos + 8].sprite = pieceImgWhite[11];
                                boardFields[clickedPos + 16].sprite = pieceImgWhite[5];
                                piecesInfo[clickedPos] = "";
                                piecesInfo[clickedPos + 8] = "";
                                piecesInfo[clickedPos + 16] = clickedPiece;
                            }else if(clickedPiece == "pawn_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                boardFields[clickedPos - 8].sprite = pieceImgBlack[11];
                                boardFields[clickedPos - 16].sprite = pieceImgBlack[5];
                                piecesInfo[clickedPos] = "";
                                piecesInfo[clickedPos - 8] = "";
                                piecesInfo[clickedPos - 16] = clickedPiece;
                            }else if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos + 15].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos + 15] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }
                        else if(piecesInfo[i] == "MoveOptionC"){
                            if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos + 17].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos + 17] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }
                        else if(piecesInfo[i] == "MoveOptionD"){
                            if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos + 10].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos + 10] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }
                        else if(piecesInfo[i] == "MoveOptionE"){
                            if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 6].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos - 6] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }
                        else if(piecesInfo[i] == "MoveOptionF"){
                            if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 15].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos - 15] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }
                        else if(piecesInfo[i] == "MoveOptionG"){
                            if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 17].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos - 17] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }
                        else if(piecesInfo[i] == "MoveOptionH"){
                            if(clickedPiece == "knight_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 10].sprite = pieceImgWhite[1];
                                piecesInfo[clickedPos - 10] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgWhite[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i].Contains(piecesName[j])){
                            if(alrClicked){
                                CancelMoving();
                            }       
                            clickedPos = i;
                            clickedPiece = piecesName[j];
                            Debug.Log(clickedPiece);
                            if(clickedPiece.Contains("white")){
                                MovingPiecesWhite();
                            }else if(clickedPiece.Contains("black")){
                                MovingPiecesBlack();
                            }
                            alrClicked = true;
                            wasClicked = false;
                            break;
                        }
                    }
                }
            }
        }
    }

    protected void MovingPiecesWhite(){
        if(clickedPiece == "pawn_white"){
            if(piecesInfo[clickedPos + 8] == ""){
                boardFields[clickedPos + 8].sprite = circleBlack;
                piecesInfo[clickedPos + 8] = "MoveOptionA";
        ////firstmovepawnswhitecheck
                if(piecesInfo[clickedPos] == "pawn_whiteA2" && firstMove[0] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_whiteB2" && firstMove[1] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_whiteC2" && firstMove[2] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_whiteD2" && firstMove[3] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_whiteE2" && firstMove[4] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_whiteF2" && firstMove[5] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_whiteG2" && firstMove[6] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_whiteH2" && firstMove[7] && piecesInfo[clickedPos + 16] == ""){
                    boardFields[clickedPos + 16].sprite = circleBlack;
                    piecesInfo[clickedPos + 16] = "MoveOptionB";
                }
            }
        //
        }else if(clickedPiece == "knight_white"){
            if(boardFields[clickedPos].tag != "A2" && boardFields[clickedPos].tag != "A3 - A6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "G8" && boardFields[clickedPos].tag != "H8" && boardFields[clickedPos].tag != "C8 - F8" && boardFields[clickedPos].tag != "A7" && boardFields[clickedPos].tag != "B7"){
                if(boardFields[clickedPos].tag != "A1"  && boardFields[clickedPos].tag != "B1" && boardFields[clickedPos].tag != "B3 - B6"){
                    if(piecesInfo[clickedPos + 6] == ""){
                        boardFields[clickedPos + 6].sprite = circleBlack;
                        piecesInfo[clickedPos + 6] = "MoveOptionA";
                    }
                }
                if(boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7"){
                    if(piecesInfo[clickedPos + 15] == ""){
                        boardFields[clickedPos + 15].sprite = circleBlack;
                        piecesInfo[clickedPos + 15] = "MoveOptionB";
                    }
                }
            }
            if(boardFields[clickedPos].tag != "H1" && boardFields[clickedPos].tag != "H3 - H6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "G8" && boardFields[clickedPos].tag != "H8" && boardFields[clickedPos].tag != "C8 - F8" && boardFields[clickedPos].tag != "A7" && boardFields[clickedPos].tag != "B7" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7"){
                if(piecesInfo[clickedPos + 17] == ""){
                    boardFields[clickedPos + 17].sprite = circleBlack;
                    piecesInfo[clickedPos + 17] = "MoveOptionC";
                }
            }
            if(boardFields[clickedPos].tag != "A1"  && boardFields[clickedPos].tag != "H1"  && boardFields[clickedPos].tag != "G1"){
                if(boardFields[clickedPos].tag != "G2" && boardFields[clickedPos].tag != "H3 - H6"){
                    if(boardFields[clickedPos].tag != "G3 - G6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "G8" && boardFields[clickedPos].tag != "H8" && boardFields[clickedPos].tag != "C8 - F8" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7"){
                        if(piecesInfo[clickedPos + 10] == ""){
                            boardFields[clickedPos + 10].sprite = circleBlack;
                            piecesInfo[clickedPos + 10] = "MoveOptionD";
                        }
                    }
                    if(boardFields[clickedPos].tag != "B1"  && boardFields[clickedPos].tag != "C1 - F1"){
                        if(boardFields[clickedPos].tag != "H1 - H6" && boardFields[clickedPos].tag != "G3 - G6" && boardFields[clickedPos].tag != "G8" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7"){
                            if(piecesInfo[clickedPos - 6] == ""){
                                boardFields[clickedPos - 6].sprite = circleBlack;
                                piecesInfo[clickedPos - 6] = "MoveOptionE";
                            }
                        }
                        if(boardFields[clickedPos].tag != "A2" && boardFields[clickedPos].tag != "B2" && boardFields[clickedPos].tag != "C2 - F2"){
                            if(boardFields[clickedPos].tag != "H3 - H6" && boardFields[clickedPos].tag != "H8" && boardFields[clickedPos].tag != "H7"){
                                if(piecesInfo[clickedPos - 15] == ""){
                                    boardFields[clickedPos - 15].sprite = circleBlack;
                                    piecesInfo[clickedPos - 15] = "MoveOptionF";
                                }
                            }
                            if(boardFields[clickedPos].tag != "A3 - A6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "A7"){
                                if(piecesInfo[clickedPos - 17] == ""){
                                    boardFields[clickedPos - 17].sprite = circleBlack;
                                    piecesInfo[clickedPos - 17] = "MoveOptionG";
                                }
                            }
                        }
                    }
                }   
                if(boardFields[clickedPos].tag != "B1" && boardFields[clickedPos].tag != "C1 - F1" && boardFields[clickedPos].tag != "A2" && boardFields[clickedPos].tag != "B2" && boardFields[clickedPos].tag != "A3 - A6" && boardFields[clickedPos].tag != "B3 - B6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "A7" && boardFields[clickedPos].tag != "B7"){
                    if(piecesInfo[clickedPos - 10] == ""){
                        boardFields[clickedPos - 10].sprite = circleBlack;
                        piecesInfo[clickedPos - 10] = "MoveOptionH";
                    }
                }
            }
        }
    }

    protected void MovingPiecesBlack(){
        if(clickedPiece == "pawn_black"){
            if(piecesInfo[clickedPos - 8] == ""){
                boardFields[clickedPos - 8].sprite = circleBlack;
                piecesInfo[clickedPos - 8] = "MoveOptionA";
        ////firstmovepawnsblackcheck
                if(piecesInfo[clickedPos] == "pawn_blackA7" && firstMove[8] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_blackB7" && firstMove[9] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_blackC7" && firstMove[10] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_blackD7" && firstMove[11] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_blackE7" && firstMove[12] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_blackF7" && firstMove[13] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_blackG7" && firstMove[14] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
                if(piecesInfo[clickedPos] == "pawn_blackH7" && firstMove[15] && piecesInfo[clickedPos - 16] == ""){
                    boardFields[clickedPos - 16].sprite = circleBlack;
                    piecesInfo[clickedPos - 16] = "MoveOptionB";
                }
            }
        //
        }
    }

    protected void CancelMoving(){
        if(clickedPiece == "pawn_white"){
            if(piecesInfo[clickedPos + 8] == "MoveOptionA" || piecesInfo[clickedPos + 16] == "MoveOptionB"){
                boardFields[clickedPos + 8].sprite = pieceImgWhite[11];
                piecesInfo[clickedPos + 8] = "";
                boardFields[clickedPos + 16].sprite = pieceImgWhite[11];
                piecesInfo[clickedPos + 16] = "";
                alrClicked = false;
            }
        }else if(clickedPiece == "pawn_black"){
            if(piecesInfo[clickedPos - 8] == "MoveOptionA" || piecesInfo[clickedPos - 16] == "MoveOptionB"){
                boardFields[clickedPos - 8].sprite = pieceImgBlack[11];
                piecesInfo[clickedPos - 8] = "";
                boardFields[clickedPos - 16].sprite = pieceImgBlack[11];
                piecesInfo[clickedPos - 16] = "";
                alrClicked = false;
            }    
        }else if(clickedPiece == "knight_white"){
            boardFields[clickedPos + 15].sprite = pieceImgWhite[11];
            boardFields[clickedPos + 17].sprite = pieceImgWhite[11];
            piecesInfo[clickedPos + 15] = "";
            piecesInfo[clickedPos + 17] = "";
            alrClicked = false;
        }
    }
}
////DODAĆ C7 - F7 I CZANRE KONIE