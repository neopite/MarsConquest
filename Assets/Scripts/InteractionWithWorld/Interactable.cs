using System;
using UnityEngine;

namespace InteractionWithWorld
{
    public abstract class Interactable : MonoBehaviour
    {
        public enum InteractionType
        {
            Hold,
            Press
        }

        public InteractionType interactType;
        public InteractionType InteractType
        {
            get => interactType;
            private set => interactType = value;
        }

        public abstract String GetDescription();
        public abstract void Interact();
    }
}