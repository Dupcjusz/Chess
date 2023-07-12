using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Bishop_white : MonoBehaviour
{
    public GameObject bishop_C1;
    public GameObject bishop_F1;

    void Start()
    {
        bishop_C1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40.5f, -95);
        bishop_F1.GetComponent<RectTransform>().anchoredPosition = new Vector2(40.5f, -95);
    }
}
