using System;
using DefaultNamespace;
using UnityEngine;

namespace InteractionWithWorld
{
    public class CollectOre : Interactable
    {
        private IResource _resource;

        private void Start()
        {
            _resource = GetComponent<BaseResource>();
        }
        
        public  InteractionType InteractType { get; set; }

        public override string GetDescription()
        {
            return "Press E to mine " + InteractType.ToString();
        }

        public override void Interact()
        {
           int materialGain = _resource.Collect(2);
            GameEvents.Instance.ResourceDisplayOnPupupPanel(materialGain);
            GameEvents.Instance.ReceiveResource(2 , _resource.ResourceType);
            Debug.Log("Mined 2 ores" + " remains : " + _resource.Amount);
        }
        
    }
}