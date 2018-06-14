using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace cln
{
    public class Splash : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(LoadMain());
        }

        private IEnumerator LoadMain()
        {
            yield return new WaitForSeconds(3f);
        
            SceneManager.LoadScene("Main");
        }
    }
}