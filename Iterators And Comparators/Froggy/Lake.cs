using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        public List<int> Collection { get; set; }

        public Lake(List<int> list)
        {
            Collection = list;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return Collection[i];
                }
            }
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return Collection[i];
                }
            }

            

            
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
