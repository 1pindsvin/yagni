using System.Collections;
using System.Collections.Generic;

namespace DataService.Model
{
    public interface ISequencer<T> : IEnumerator<T> 
    {
    }
}