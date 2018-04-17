using UnityEngine;

namespace cln
{
    public class Menu : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}