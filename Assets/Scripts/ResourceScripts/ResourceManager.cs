using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourceManager : MonoBehaviour
    {
        private Dictionary<ResourceType, uint> PlayerResources;

        public static ResourceManager Instance { get; private set; }

        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }else  Destroy(gameObject);
            
            DontDestroyOnLoad(gameObject); 
            InitializeManager();
        }

        private void InitializeManager()
        {
            List<ResourceType> listOfEnums = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>().ToList();
            foreach (ResourceType type in listOfEnums)
            {
                PlayerResources.Add(type,0);
            }
        }
        
    }
}