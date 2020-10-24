using System;
using System.Collections.Generic;
using System.Text;

namespace GameCom.Model.Base
{
    public interface IVersionable
    {
        int Version { get; set; }
    }
}
