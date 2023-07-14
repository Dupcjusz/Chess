using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Queen_black : Board_manager
{
    private Image queen_D8;

    void Awake(){
        Setup();

        queen_D8 = boardFields[59];
    }

    void Start(){
    
    }
}
