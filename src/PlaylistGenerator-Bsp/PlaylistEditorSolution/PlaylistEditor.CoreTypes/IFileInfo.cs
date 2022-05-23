using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistEditor.CoreTypes
{
    public interface IFileInfo
    {
        string Description { get; }
        string Extension { get; }
    }
}
