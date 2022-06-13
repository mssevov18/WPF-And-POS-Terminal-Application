using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_And_POS_Terminal_App.Interfaces
{
    interface IPayment
    {
        public float Total { get; set; }

        public void Update(float Total);
    }
}
