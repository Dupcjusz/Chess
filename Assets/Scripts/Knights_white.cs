using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Knights_white : Board_manager
{
    private Image knight_B1;
    private Image knight_G1;

    void Awake(){
        Setup();

        knight_B1 = boardFields[1];
        knight_G1 = boardFields[6];
    }

    void Start(){
        
    }
}
