using System;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class BaseResource :  MonoBehaviour, IResource
    {

        public UnityEvent changeResourceQuantity;
       [SerializeField] private ResourceType _resourceType;
       [SerializeField] private int _amount;
       
        public ResourceType ResourceType
        {
            get => _resourceType;
            set => _resourceType = value;
        }

        public int Amount
        {
            get => _amount;
            set => _amount = value;

        }
        
        public void Collect(int quantityGainResource)
        {
            Amount -= quantityGainResource;
            int materialGain;
            if (Amount < 0)
            {
                materialGain = Amount + quantityGainResource;
            }
            else materialGain = quantityGainResource;

            if (Amount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}