using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reederei
{
    public class Staffmember : Person
    {
        public System.Collections.Generic.List<Qualification> Qualifications
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Crew Crew
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public bool IsAssigned
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}