using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MudancaDeCena : MonoBehaviour
{
    public void MudarDeCena(string name)
    {
        SceneManager.LoadScene(name);
    }
}
