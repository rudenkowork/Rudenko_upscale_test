using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ListExtensions
    {
        public static T PickRandom<T>(this List<T> list)
        {
            int elementsAmount = list.Count;
            int index = Random.Range(0, elementsAmount - 1);
            
            return list[index];
        }   
    }
}