using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPoints : MonoBehaviour
{
    public Text scoreText;

    [SerializeField]
    private FloatSO scoreSO;

    private void Start()
    {
        scoreText.text = ": " + scoreSO.Value + "";
    }
}
