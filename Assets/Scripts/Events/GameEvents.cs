using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents Instance;
        public event Action<int> OnResourceDisplayOnPupupPanel;

        public void ResourceDisplayOnPupupPanel(int newQuantity)
        {
            if (OnResourceDisplayOnPupupPanel != null)
            {
                OnResourceDisplayOnPupupPanel(newQuantity);
            }
        }

        public event Action<uint, ResourceType> OnReceiveResource;

        public void ReceiveResource(uint quantity, ResourceType resourceType)
        {
            if (OnReceiveResource != null)
            {
                OnReceiveResource(quantity,resourceType);
            }
        }
        
        private void Awake(){
            if (Instance == null)
            {
                Instance = this;
            } else Destroy(gameObject);
        }
    }
}