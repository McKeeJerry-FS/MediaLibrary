using Grpc.Core;
using MediaLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Contracts
{
    public partial class MovieContract
    {
        public partial class MovieContractClient : IContractClient<Movie>{}
    }
}
