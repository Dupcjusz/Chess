using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Queen_white : Board_manager
{
    private Image queen_D1;

    void Awake(){
        Setup();

        queen_D1 = boardFields[3];
    }

    void Start(){
        
    }
}
