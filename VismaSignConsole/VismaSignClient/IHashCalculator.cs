using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaSignClientLib
{
    public interface IHashCalculator
    {
        byte[] GetContentMd5(IRequest request);
        string GetMac(IRequest request);
    }
}
