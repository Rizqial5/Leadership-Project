using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leadership.Menu
{
    public class ChangeScene : MonoBehaviour
    {
        [SerializeField] string nameScene;

        public void NextScene()
        {
            SceneManager.LoadScene(nameScene);
        }

        public void AppQuit()
        {
            Application.Quit();
        }
    }
}
