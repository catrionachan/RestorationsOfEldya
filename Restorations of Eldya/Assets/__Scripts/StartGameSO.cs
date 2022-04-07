using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSO : MonoBehaviour
{
    [SerializeField]
    private FloatSO scoreSO;

    // Start is called before the first frame update
    void Start()
    {
        scoreSO.Value = 0;
        
    }
}
