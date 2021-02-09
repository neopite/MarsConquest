using UnityEngine;

namespace DefaultNamespace
{
    public interface IResource : Collectable
    {
        
        ResourceType ResourceType { get;  set;}
        int Amount {get; set; }
        
    }
}