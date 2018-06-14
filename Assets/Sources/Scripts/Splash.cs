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
            yield return new WaitForSeconds(1f);
        
            SceneManager.LoadScene("Main");
        }
    }
}