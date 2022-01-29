using UnityEngine;

namespace UI
{
    public class BaseView : MonoBehaviour
    {
        public virtual void ShowView()
        {
            gameObject.SetActive(true);
        }

        public virtual void HideView()
        {
            gameObject.SetActive(false);
        }
    }
}