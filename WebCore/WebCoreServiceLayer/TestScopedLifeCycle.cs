using System;
using System.Collections.Generic;
using System.Text;

namespace WebCoreServiceLayer
{
  public  class TestScopedLifeCycle
    {
        public int Id { get; set; }


        public void Add()
        {
            Id = Id + 1;
        }

    }
}
