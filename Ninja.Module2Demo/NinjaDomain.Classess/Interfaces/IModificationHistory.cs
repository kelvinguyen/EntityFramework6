using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDomain.Classess.Interfaces
{
    public interface IModificationHistory
    {
        DateTime DateModify { get; set; }
        DateTime DateCreate { get; set; }
        bool IsDirty { get; set; }

    }
}
