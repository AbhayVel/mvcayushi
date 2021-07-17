using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
   public  class ModelState
    {

      public  ModelState()
        {
            Errors = new Dictionary<string, List<string>>();
        }
        public Dictionary<string,List<string>> Errors { get; set; }
        public bool IsValid { get{

                return Errors.Count == 0;

                    }
                
                }
    }
}
