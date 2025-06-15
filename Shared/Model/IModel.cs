using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Shared.Model
{
    public interface IModel
    {
        int Id { get; set; }
        string Name { get; }
    }
}
