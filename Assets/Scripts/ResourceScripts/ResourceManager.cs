using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourceManager : MonoBehaviour
    {
        private Dictionary<ResourceType, uint> _playerResources;

        public static ResourceManager Instance { get; private set; }

        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }else  Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject); 
            InitializeManager();
            GameEvents.Instance.OnReceiveResource += ReceiveResource;
        }

        private void InitializeManager()
        {
            List<ResourceType> listOfEnums = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>().ToList();
            _playerResources = new Dictionary<ResourceType, uint>();
            foreach (ResourceType type in listOfEnums)
            {
                _playerResources.Add(type,0);
            }
        }

        public void ReceiveResource(uint resourceQuantity, ResourceType type)
        {
            _playerResources[type] = _playerResources[type] + resourceQuantity;
        }

        public void TakeAwayResourceQuantity(int quantity, ResourceType type)
        {
            uint currentResourceQuantity = _playerResources[type];
            _playerResources[type] = (uint) (currentResourceQuantity - quantity);
        }
    }
}