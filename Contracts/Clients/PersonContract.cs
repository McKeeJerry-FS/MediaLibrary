using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Contracts
{

    public partial class PersonContract 
    {
        public partial class PersonContractClient : IContractClient<Person>
        {
            public AsyncUnaryCall<CreateResponse> CreateAsync(Person request, Metadata? headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public AsyncUnaryCall<GenericResponse> DeleteAsync(ItemRequest request, Metadata? headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public AsyncUnaryCall<Person> GetAsync(ItemRequest request, Metadata? headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public AsyncServerStreamingCall<Person> GetList(Empty request, Metadata? headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public AsyncUnaryCall<GenericResponse> UpdateAsync(Person request, Metadata? headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }
    }
    
}
