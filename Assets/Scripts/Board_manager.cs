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
    private int i, n, j, l, t;
    private string clickedField;
    private string clickedPiece;
    private string[] alphabet = new string[26]; 
    private int clickedPos;
    private bool wasClicked = false, alrClicked = false, blocked = false;
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
                //Debug.Log("Pressed left click, casting ray");
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
        
        piecesInfo[8] = "";
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

        alphabet[0] = "A";
        alphabet[1] = "B";
        alphabet[2] = "C";
        alphabet[3] = "D";
        alphabet[4] = "E";
        alphabet[5] = "F";
        alphabet[6] = "G";
        alphabet[7] = "H";
        alphabet[8] = "I";
        alphabet[9] = "J";
        alphabet[10] = "K";
        alphabet[11] = "L";
        alphabet[12] = "M";
        alphabet[13] = "N";
        alphabet[14] = "O";
        alphabet[15] = "P";
        alphabet[16] = "Q";
        alphabet[17] = "R";
        alphabet[18] = "S";
        alphabet[19] = "T";
        alphabet[20] = "U";
        alphabet[21] = "V";
        alphabet[22] = "W";
        alphabet[23] = "X";
        alphabet[24] = "Y";
        alphabet[25] = "Z";
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
                            }else if(clickedPiece == "knight_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos + 6].sprite = pieceImgBlack[1];
                                piecesInfo[clickedPos + 6] = clickedPiece;
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                    boardFields[clickedPos + 10].sprite = pieceImgBlack[11];
                                    piecesInfo[clickedPos + 10] = "";
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A")){
                                    boardFields[0].sprite = pieceImgWhite[0];
                                    piecesInfo[0] = clickedPiece;
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[1].sprite = pieceImgWhite[0];
                                    piecesInfo[1] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[2].sprite = pieceImgWhite[0];
                                    piecesInfo[2] = clickedPiece;     
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[3].sprite = pieceImgWhite[0];
                                    piecesInfo[3] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[4].sprite = pieceImgWhite[0];
                                    piecesInfo[4] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[5].sprite = pieceImgWhite[0];
                                    piecesInfo[5] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[6].sprite = pieceImgWhite[0];
                                    piecesInfo[6] = clickedPiece;    
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[7].sprite = pieceImgWhite[0];
                                    piecesInfo[7] = clickedPiece;      
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
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
                            }else if(clickedPiece == "knight_black"){
                                    boardFields[clickedPos].sprite = pieceImgBlack[11];
                                    piecesInfo[clickedPos] = "";
                                    boardFields[clickedPos + 15].sprite = pieceImgBlack[1];
                                    piecesInfo[clickedPos + 15] = clickedPiece;
                                    if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                        if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                            boardFields[clickedPos + 6].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos + 6] = "";
                                        }
                                    }
                                    if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                        if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                            boardFields[clickedPos + 17].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos + 17] = "";
                                        }
                                    }
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                    if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                        if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                            boardFields[clickedPos - 6].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 6] = "";
                                        }
                                    }
                                    if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                        if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                            boardFields[clickedPos - 15].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 15] = "";
                                        }
                                    }
                                    if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                        if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                            boardFields[clickedPos - 17].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 17] = "";
                                        }
                                    }
                                    if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                        if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                            boardFields[clickedPos - 10].sprite = pieceImgBlack[11];
                                            piecesInfo[clickedPos - 10] = "";
                                        }
                                    }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A")){
                                    boardFields[8].sprite = pieceImgWhite[0];
                                    piecesInfo[8] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[9].sprite = pieceImgWhite[0];
                                    piecesInfo[9] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[10].sprite = pieceImgWhite[0];
                                    piecesInfo[10] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[11].sprite = pieceImgWhite[0];
                                    piecesInfo[11] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[12].sprite = pieceImgWhite[0];
                                    piecesInfo[12] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[13].sprite = pieceImgWhite[0];
                                    piecesInfo[13] = clickedPiece;  
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[14].sprite = pieceImgWhite[0];
                                    piecesInfo[14] = clickedPiece;     
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[15].sprite = pieceImgWhite[0];
                                    piecesInfo[15] = clickedPiece;      
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }     
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionC"){
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
                            }else if(clickedPiece == "knight_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos + 17].sprite = pieceImgBlack[1];
                                piecesInfo[clickedPos + 17] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A")){
                                    boardFields[16].sprite = pieceImgWhite[0];
                                    piecesInfo[16] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[17].sprite = pieceImgWhite[0];
                                    piecesInfo[17] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[18].sprite = pieceImgWhite[0];
                                    piecesInfo[18] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[19].sprite = pieceImgWhite[0];
                                    piecesInfo[19] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[20].sprite = pieceImgWhite[0];
                                    piecesInfo[20] = clickedPiece;     
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[21].sprite = pieceImgWhite[0];
                                    piecesInfo[21] = clickedPiece;     
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[22].sprite = pieceImgWhite[0];
                                    piecesInfo[22] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[23].sprite = pieceImgWhite[0];
                                    piecesInfo[23] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }   
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionD"){
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
                            }else if(clickedPiece == "knight_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos + 10].sprite = pieceImgBlack[1];
                                piecesInfo[clickedPos + 10] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A") || boardFieldsInfo[clickedPos].Contains("4")){
                                    Debug.Log("22");
                                    boardFields[24].sprite = pieceImgWhite[0];
                                    piecesInfo[24] = clickedPiece;     
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[25].sprite = pieceImgWhite[0];
                                    piecesInfo[25] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[26].sprite = pieceImgWhite[0];
                                    piecesInfo[26] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[27].sprite = pieceImgWhite[0];
                                    piecesInfo[27] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[28].sprite = pieceImgWhite[0];
                                    piecesInfo[28] = clickedPiece;     
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[29].sprite = pieceImgWhite[0];
                                    piecesInfo[29] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[30].sprite = pieceImgWhite[0];
                                    piecesInfo[30] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[31].sprite = pieceImgWhite[0];
                                    piecesInfo[31] = clickedPiece;      
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }    
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionE"){
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
                            }else if(clickedPiece == "knight_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 6].sprite = pieceImgBlack[1];
                                piecesInfo[clickedPos - 6] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A")){
                                    boardFields[32].sprite = pieceImgWhite[0];
                                    piecesInfo[32] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[33].sprite = pieceImgWhite[0];
                                    piecesInfo[33] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[34].sprite = pieceImgWhite[0];
                                    piecesInfo[34] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[35].sprite = pieceImgWhite[0];
                                    piecesInfo[35] = clickedPiece;     
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[36].sprite = pieceImgWhite[0];
                                    piecesInfo[36] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[37].sprite = pieceImgWhite[0];
                                    piecesInfo[37] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[38].sprite = pieceImgWhite[0];
                                    piecesInfo[38] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[39].sprite = pieceImgWhite[0];
                                    piecesInfo[39] = clickedPiece;      
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }     
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionF"){
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
                            }else if(clickedPiece == "knight_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 15].sprite = pieceImgBlack[1];
                                piecesInfo[clickedPos - 15] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A")){
                                    boardFields[40].sprite = pieceImgWhite[0];
                                    piecesInfo[40] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[41].sprite = pieceImgWhite[0];
                                    piecesInfo[41] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[42].sprite = pieceImgWhite[0];
                                    piecesInfo[42] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[43].sprite = pieceImgWhite[0];
                                    piecesInfo[43] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[44].sprite = pieceImgWhite[0];
                                    piecesInfo[44] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[45].sprite = pieceImgWhite[0];
                                    piecesInfo[45] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[46].sprite = pieceImgWhite[0];
                                    piecesInfo[46] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[47].sprite = pieceImgWhite[0];
                                    piecesInfo[47] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }        
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionG"){
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
                            }else if(clickedPiece == "knight_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 17].sprite = pieceImgBlack[1];
                                piecesInfo[clickedPos - 17] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 10 < 64 && clickedPos - 10 > 0){
                                    if(piecesInfo[clickedPos - 10] == "MoveOptionH"){
                                        boardFields[clickedPos - 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 10] = "";
                                    }
                                }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A")){
                                    boardFields[48].sprite = pieceImgWhite[0];
                                    piecesInfo[48] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[49].sprite = pieceImgWhite[0];
                                    piecesInfo[49] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[50].sprite = pieceImgWhite[0];
                                    piecesInfo[50] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[51].sprite = pieceImgWhite[0];
                                    piecesInfo[51] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[52].sprite = pieceImgWhite[0];
                                    piecesInfo[52] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[53].sprite = pieceImgWhite[0];
                                    piecesInfo[53] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[54].sprite = pieceImgWhite[0];
                                    piecesInfo[54] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[55].sprite = pieceImgWhite[0];
                                    piecesInfo[55] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }   
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionH"){
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
                            }else if(clickedPiece == "knight_black"){
                                boardFields[clickedPos].sprite = pieceImgBlack[11];
                                piecesInfo[clickedPos] = "";
                                boardFields[clickedPos - 10].sprite = pieceImgBlack[1];
                                piecesInfo[clickedPos - 10] = clickedPiece;
                                if(clickedPos + 6 < 64 && clickedPos + 6 > 0){
                                    if(piecesInfo[clickedPos + 6] == "MoveOptionA"){
                                        boardFields[clickedPos + 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 6] = "";
                                    }
                                }
                                if(clickedPos + 15 < 64 && clickedPos + 15 > 0){
                                    if(piecesInfo[clickedPos + 15] == "MoveOptionB"){
                                        boardFields[clickedPos + 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 15] = "";
                                    }
                                }
                                if(clickedPos + 17 < 64 && clickedPos + 17 > 0){
                                    if(piecesInfo[clickedPos + 17] == "MoveOptionC"){
                                        boardFields[clickedPos + 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 17] = "";
                                    }
                                }
                                if(clickedPos + 10 < 64 && clickedPos + 10 > 0){
                                    if(piecesInfo[clickedPos + 10] == "MoveOptionD"){
                                        boardFields[clickedPos + 10].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos + 10] = "";
                                    }
                                }
                                if(clickedPos - 6 < 64 && clickedPos - 6 > 0){
                                    if(piecesInfo[clickedPos - 6] == "MoveOptionE"){
                                        boardFields[clickedPos - 6].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 6] = "";
                                    }
                                }
                                if(clickedPos - 15 < 64 && clickedPos - 15 > 0){
                                    if(piecesInfo[clickedPos - 15] == "MoveOptionF"){
                                        boardFields[clickedPos - 15].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 15] = "";
                                    }
                                }
                                if(clickedPos - 17 < 64 && clickedPos - 17 > 0){
                                    if(piecesInfo[clickedPos - 17] == "MoveOptionG"){
                                        boardFields[clickedPos - 17].sprite = pieceImgBlack[11];
                                        piecesInfo[clickedPos - 17] = "";
                                    }
                                }
                            }else if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("A")){
                                    boardFields[56].sprite = pieceImgWhite[0];
                                    piecesInfo[56] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("B")){
                                    boardFields[57].sprite = pieceImgWhite[0];
                                    piecesInfo[57] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("C")){
                                    boardFields[58].sprite = pieceImgWhite[0];
                                    piecesInfo[58] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("D")){
                                    boardFields[59].sprite = pieceImgWhite[0];
                                    piecesInfo[59] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("E")){
                                    boardFields[60].sprite = pieceImgWhite[0];
                                    piecesInfo[60] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("F")){
                                    boardFields[61].sprite = pieceImgWhite[0];
                                    piecesInfo[61] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("G")){
                                    boardFields[62].sprite = pieceImgWhite[0];
                                    piecesInfo[62] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("H")){
                                    boardFields[63].sprite = pieceImgWhite[0];
                                    piecesInfo[63] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                } 
                            }    
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionI"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[0].sprite = pieceImgWhite[0];
                                    piecesInfo[0] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[8].sprite = pieceImgWhite[0];
                                    piecesInfo[8] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[16].sprite = pieceImgWhite[0];
                                    piecesInfo[16] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[24].sprite = pieceImgWhite[0];
                                    piecesInfo[24] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[32].sprite = pieceImgWhite[0];
                                    piecesInfo[32] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[40].sprite = pieceImgWhite[0];
                                    piecesInfo[40] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[48].sprite = pieceImgWhite[0];
                                    piecesInfo[48] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[56].sprite = pieceImgWhite[0];
                                    piecesInfo[56] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                } 
                                      
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionJ"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[1].sprite = pieceImgWhite[0];
                                    piecesInfo[1] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[9].sprite = pieceImgWhite[0];
                                    piecesInfo[9] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[17].sprite = pieceImgWhite[0];
                                    piecesInfo[17] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[25].sprite = pieceImgWhite[0];
                                    piecesInfo[25] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[33].sprite = pieceImgWhite[0];
                                    piecesInfo[33] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[41].sprite = pieceImgWhite[0];
                                    piecesInfo[41] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[49].sprite = pieceImgWhite[0];
                                    piecesInfo[49] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[57].sprite = pieceImgWhite[0];
                                    piecesInfo[57] = clickedPiece;      
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }       
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;
                        }else if(piecesInfo[i] == "MoveOptionK"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[2].sprite = pieceImgWhite[0];
                                    piecesInfo[2] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[10].sprite = pieceImgWhite[0];
                                    piecesInfo[10] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[18].sprite = pieceImgWhite[0];
                                    piecesInfo[18] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[26].sprite = pieceImgWhite[0];
                                    piecesInfo[26] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[34].sprite = pieceImgWhite[0];
                                    piecesInfo[34] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[42].sprite = pieceImgWhite[0];
                                    piecesInfo[42] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[50].sprite = pieceImgWhite[0];
                                    piecesInfo[50] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[58].sprite = pieceImgWhite[0];
                                    piecesInfo[58] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }    
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;  
                        }else if(piecesInfo[i] == "MoveOptionL"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[3].sprite = pieceImgWhite[0];
                                    piecesInfo[3] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[11].sprite = pieceImgWhite[0];
                                    piecesInfo[11] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[19].sprite = pieceImgWhite[0];
                                    piecesInfo[19] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[27].sprite = pieceImgWhite[0];
                                    piecesInfo[27] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[35].sprite = pieceImgWhite[0];
                                    piecesInfo[35] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[43].sprite = pieceImgWhite[0];
                                    piecesInfo[43] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[51].sprite = pieceImgWhite[0];
                                    piecesInfo[51] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[59].sprite = pieceImgWhite[0];
                                    piecesInfo[59] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }    
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;  
                        }else if(piecesInfo[i] == "MoveOptionM"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[4].sprite = pieceImgWhite[0];
                                    piecesInfo[4] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[12].sprite = pieceImgWhite[0];
                                    piecesInfo[12] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[20].sprite = pieceImgWhite[0];
                                    piecesInfo[20] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[28].sprite = pieceImgWhite[0];
                                    piecesInfo[28] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[36].sprite = pieceImgWhite[0];
                                    piecesInfo[36] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[44].sprite = pieceImgWhite[0];
                                    piecesInfo[44] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[52].sprite = pieceImgWhite[0];
                                    piecesInfo[52] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[60].sprite = pieceImgWhite[0];
                                    piecesInfo[60] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }    
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;  
                        }else if(piecesInfo[i] == "MoveOptionN"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[5].sprite = pieceImgWhite[0];
                                    piecesInfo[5] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[13].sprite = pieceImgWhite[0];
                                    piecesInfo[13] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[21].sprite = pieceImgWhite[0];
                                    piecesInfo[21] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[29].sprite = pieceImgWhite[0];
                                    piecesInfo[29] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[37].sprite = pieceImgWhite[0];
                                    piecesInfo[37] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[45].sprite = pieceImgWhite[0];
                                    piecesInfo[45] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[53].sprite = pieceImgWhite[0];
                                    piecesInfo[53] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[61].sprite = pieceImgWhite[0];
                                    piecesInfo[61] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }    
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;  
                        }else if(piecesInfo[i] == "MoveOptionO"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[6].sprite = pieceImgWhite[0];
                                    piecesInfo[6] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[14].sprite = pieceImgWhite[0];
                                    piecesInfo[14] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[22].sprite = pieceImgWhite[0];
                                    piecesInfo[22] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[30].sprite = pieceImgWhite[0];
                                    piecesInfo[30] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[38].sprite = pieceImgWhite[0];
                                    piecesInfo[38] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[46].sprite = pieceImgWhite[0];
                                    piecesInfo[46] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[54].sprite = pieceImgWhite[0];
                                    piecesInfo[54] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[62].sprite = pieceImgWhite[0];
                                    piecesInfo[62] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
                                    }
                                }    
                            }
                            alrClicked = false;
                            wasClicked = false;
                            break;  
                        }else if(piecesInfo[i] == "MoveOptionP"){
                            if(clickedPiece == "rook_white"){
                                boardFields[clickedPos].sprite = pieceImgWhite[11];
                                piecesInfo[clickedPos] = "";
                                if(boardFieldsInfo[clickedPos].Contains("1")){
                                    boardFields[7].sprite = pieceImgWhite[0];
                                    piecesInfo[7] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("2")){
                                    boardFields[15].sprite = pieceImgWhite[0];
                                    piecesInfo[15] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("3")){
                                    boardFields[23].sprite = pieceImgWhite[0];
                                    piecesInfo[23] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("4")){
                                    boardFields[31].sprite = pieceImgWhite[0];
                                    piecesInfo[31] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("5")){
                                    boardFields[39].sprite = pieceImgWhite[0];
                                    piecesInfo[39] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("6")){
                                    boardFields[47].sprite = pieceImgWhite[0];
                                    piecesInfo[47] = clickedPiece;      
                                }else if(boardFieldsInfo[clickedPos].Contains("7")){
                                    boardFields[55].sprite = pieceImgWhite[0];
                                    piecesInfo[55] = clickedPiece;       
                                }else if(boardFieldsInfo[clickedPos].Contains("8")){
                                    boardFields[63].sprite = pieceImgWhite[0];
                                    piecesInfo[63] = clickedPiece;       
                                }
                                for(i = 0; i < 64; i++){
                                    if(piecesInfo[i].Contains("MoveOption")){
                                        boardFields[i].sprite = pieceImgWhite[11];
                                        piecesInfo[i] = "";
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
                            blocked = false;
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
                if(boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7" && boardFields[clickedPos].tag != "C7 - F7"){
                    if(piecesInfo[clickedPos + 15] == ""){
                        boardFields[clickedPos + 15].sprite = circleBlack;
                        piecesInfo[clickedPos + 15] = "MoveOptionB";
                    }
                }
            }
            if(boardFields[clickedPos].tag != "H1" && boardFields[clickedPos].tag != "H3 - H6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "G8" && boardFields[clickedPos].tag != "H8" && boardFields[clickedPos].tag != "C8 - F8" && boardFields[clickedPos].tag != "A7" && boardFields[clickedPos].tag != "B7" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7" && boardFields[clickedPos].tag != "C7 - F7"){
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
        }else if (clickedPiece == "rook_white"){
            if(boardFieldsInfo[clickedPos].Contains("A")){
                t = 0;
            }else if(boardFieldsInfo[clickedPos].Contains("B")){
                t = 1;
            }else if(boardFieldsInfo[clickedPos].Contains("C")){
                t = 2;
            }else if(boardFieldsInfo[clickedPos].Contains("D")){
                t = 3;
            }else if(boardFieldsInfo[clickedPos].Contains("E")){
                t = 4;
            }else if(boardFieldsInfo[clickedPos].Contains("F")){
                t = 5;
            }else if(boardFieldsInfo[clickedPos].Contains("G")){
                t = 6;
            }else if(boardFieldsInfo[clickedPos].Contains("H")){
                t = 7;
            }
            for(i = t, n = 0; i < 64; i += 8, n++){
                if(piecesInfo[i] == ""){
                    boardFields[i].sprite = circleBlack;
                    piecesInfo[i] = "MoveOption" + alphabet[n];
                }else if(!piecesInfo[i].Contains("rook_white")){
                    if(i < clickedPos){
                        for(j = i - 8; j > 0; j -= 8){
                            if(piecesInfo[j].Contains("white") || piecesInfo[j].Contains("black")){
                                break;
                            }else{
                                boardFields[j].sprite = pieceImgWhite[11];
                                piecesInfo[j] = "";
                            }
                        }
                    }else if(i > clickedPos){
                        for(j = i + 8; j < 63; j += 8){
                            if(piecesInfo[j].Contains("white") || piecesInfo[j].Contains("black")){
                                break;
                            }else{
                                boardFields[j].sprite = pieceImgWhite[11];
                                piecesInfo[j] = "";
                            }
                        }
                    }
                    continue;
                }
            }
            if(boardFieldsInfo[clickedPos].Contains("1")){
                t = 0;
            }else if(boardFieldsInfo[clickedPos].Contains("2")){
                t = 8;
            }else if(boardFieldsInfo[clickedPos].Contains("3")){
                t = 16;
            }else if(boardFieldsInfo[clickedPos].Contains("4")){
                t = 24;
            }else if(boardFieldsInfo[clickedPos].Contains("5")){
                t = 32;
            }else if(boardFieldsInfo[clickedPos].Contains("6")){
                t = 40;
            }else if(boardFieldsInfo[clickedPos].Contains("7")){
                t = 48;
            }else if(boardFieldsInfo[clickedPos].Contains("8")){
                t = 56;
            }
            for(i = t; i < t + 8; i++, n++){
                if(piecesInfo[i] == ""){
                    if(blocked){
                        blocked = false;
                        break;
                    }
                    boardFields[i].sprite = circleBlack;
                    piecesInfo[i] = "MoveOption" + alphabet[n];
                }else if(!piecesInfo[i].Contains("rook_white")){
                    if(i < clickedPos){
                        for(j = t; j < i; j++){
                            if(piecesInfo[j].Contains("white") || piecesInfo[j].Contains("black")){
                                blocked = true;
                                break;
                            }else{
                                boardFields[j].sprite = pieceImgWhite[11];
                                piecesInfo[j] = "";
                            }
                        }
                    }else if(i > clickedPos){
                        Debug.Log("c");
                        for(j = t + 7; j > clickedPos; j--){
                            if(piecesInfo[j].Contains("white") || piecesInfo[j].Contains("black")){
                                blocked = true;
                                break;
                            }else{                       
                                boardFields[j].sprite = pieceImgWhite[11];
                                piecesInfo[j] = "";
                            }
                        }
                    }
                    //continue;
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
        }else if(clickedPiece == "knight_black"){
            if(boardFields[clickedPos].tag != "A2" && boardFields[clickedPos].tag != "A3 - A6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "G8" && boardFields[clickedPos].tag != "H8" && boardFields[clickedPos].tag != "C8 - F8" && boardFields[clickedPos].tag != "A7" && boardFields[clickedPos].tag != "B7"){
                if(boardFields[clickedPos].tag != "A1"  && boardFields[clickedPos].tag != "B1" && boardFields[clickedPos].tag != "B3 - B6"){
                    if(piecesInfo[clickedPos + 6] == ""){
                        boardFields[clickedPos + 6].sprite = circleBlack;
                        piecesInfo[clickedPos + 6] = "MoveOptionA";
                    }
                }
                if(boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7" && boardFields[clickedPos].tag != "C7 - F7"){
                    if(piecesInfo[clickedPos + 15] == ""){
                        boardFields[clickedPos + 15].sprite = circleBlack;
                        piecesInfo[clickedPos + 15] = "MoveOptionB";
                    }
                }
            }
            if(boardFields[clickedPos].tag != "H1" && boardFields[clickedPos].tag != "H3 - H6" && boardFields[clickedPos].tag != "A8" && boardFields[clickedPos].tag != "B8" && boardFields[clickedPos].tag != "G8" && boardFields[clickedPos].tag != "H8" && boardFields[clickedPos].tag != "C8 - F8" && boardFields[clickedPos].tag != "A7" && boardFields[clickedPos].tag != "B7" && boardFields[clickedPos].tag != "G7" && boardFields[clickedPos].tag != "H7" && boardFields[clickedPos].tag != "C7 - F7"){
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

    protected void CancelMoving(){
        /*if(clickedPiece == "pawn_white"){
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
        }else if(clickedPiece == "rook_white"){
        }*/

        for(n = 0; n < 64; n++){
                if(piecesInfo[n].Contains("MoveOption")){
                    boardFields[n].sprite = pieceImgWhite[11];
                    piecesInfo[n] = "";
            }
        }
    }
}